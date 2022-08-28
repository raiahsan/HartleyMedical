#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HartleyMedical.Application.Common.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

#endregion

namespace HartleyMedical.WebAPI.Configurations
{
    public static class ConfigureSwagger
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection(SwaggerSettings.key).Get<SwaggerSettings>();
            services.AddEndpointsApiExplorer();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc(options.Version, new OpenApiInfo
                {
                    Version = options.Version,
                    Title = options.APIName,
                    Description = options.Description
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization header using the Bearer scheme (Example: 'Bearer qwertyuiop')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            return services;
        }
    }
}