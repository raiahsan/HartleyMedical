using Application.ServiceInterfaces.IUserServices;
using HartleyMedical.Application;
using HartleyMedical.Application.Common.Settings;
using HartleyMedical.Azure;
using HartleyMedical.Infrastructure;
using HartleyMedical.Twilio;
using HartleyMedical.WebAPI.Configurations;
using HartleyMedical.WebAPI.ModulesRegistration;
using HartleyMedical.WebAPI.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
var swaggerOptions = builder.Configuration.GetSection(SwaggerSettings.key).Get<SwaggerSettings>();

// Add services to the container.
builder.Services.RegisterModules();
builder.Services
    .AddApplication()
    .AddRepository(builder.Configuration)
    .AddCORS()
    .AddTwilioDependencies()
    .AddAzureDependencies()
    .AddSwagger(builder.Configuration);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
// configure strongly typed settings object
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(AppSettings.key));
builder.Services.Configure<SwaggerSettings>(builder.Configuration.GetSection(SwaggerSettings.key));
builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection(TwilioSettings.key));
builder.Services.Configure<AzureSettings>(builder.Configuration.GetSection(AzureSettings.key));
builder.Services.AddAuthorization();
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("RequireSuperAdminRole",
//         policy => policy.RequireRole("Super Admin"));
//});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerOptions.APIName);
    c.RoutePrefix = String.Empty;
    c.DocExpansion(DocExpansion.List);
    c.DocumentTitle = swaggerOptions.APIName;
    //c.InjectStylesheet(swaggerOptions.SwaggerUICss);
});
app.UseStaticFiles();
app.UseCors("EnableCorsFrontendProject");
app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.MapEndpoints();
app.Run();
