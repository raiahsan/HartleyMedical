using HartleyMedical.Application.ExternalDependencyInterfaces;
using HartleyMedical.Infrastructure.ExternalDependenciesImplementation;
using Microsoft.Extensions.DependencyInjection;

namespace HartleyMedical.Twilio;

public static class DependencyInjection
{
    public static IServiceCollection AddTwilioDependencies(this IServiceCollection services)
    {
        services.AddTransient<ISMSService, TwilioSMSService>();
        return services;
    }
}
