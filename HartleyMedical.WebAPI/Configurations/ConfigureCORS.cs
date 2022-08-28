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
    public static class ConfigureCORS
    {
        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("EnableCorsFrontendProject", builder =>
            {
                builder.WithOrigins("https://localhost:3000" , "http://localhost:3000", "https://dev-hartley-medical-ui.azurewebsites.net")
                    .AllowAnyMethod()
                    .AllowAnyHeader().AllowCredentials();
            }));

            return services;
        }
    }
}