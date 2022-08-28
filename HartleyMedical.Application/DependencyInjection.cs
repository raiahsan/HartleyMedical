using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using HartleyMedical.Application.Common.Behaviours;
using System.Reflection;
using AutoMapper;
using HartleyMedical.Application.Common.Mappings;
using HartleyMedical.Application.ServicesInterfaces;
using HartleyMedical.Application.Services;

namespace HartleyMedical.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        services.AddTransient<IEmailService, EmailService>();

        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MapperProfile()); });
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
