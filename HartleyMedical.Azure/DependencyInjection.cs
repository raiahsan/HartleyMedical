using HartleyMedical.Application.ExternalDependencies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Azure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAzureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IFileService, AzureFileService>();
            return services;
        }
    }
}
