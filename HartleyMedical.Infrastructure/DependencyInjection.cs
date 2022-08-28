using HartleyMedical.Application.ExternalDependencyInterfaces;
using HartleyMedical.Application.RepositoryInterfaces;
using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Application.RepositoryInterfaces.ILocationRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IStateRepositories;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Infrastructure.Persistence;
using HartleyMedical.Infrastructure.Repositories.GeneralRepositories;
using HartleyMedical.Infrastructure.Repositories.LocationRepositories;
using HartleyMedical.Infrastructure.Repositories.OrganizationRepositories;
using HartleyMedical.Infrastructure.Repositories.RoleRepositories;
using HartleyMedical.Infrastructure.Repositories.StateRepositories;
using HartleyMedical.Infrastructure.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HartleyMedical.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserToOrganizationRoleRepository, UserToOrganizationRoleRepository>();
        services.AddTransient<IDEAHistoryRepository, DEAHistoryRepository>();
        services.AddTransient<IMedicalInfoRepository, MedicalInfoRepository>();
        services.AddTransient<IUserTypeRepository, UserTypeRepository>();
        services.AddTransient<ISpecialityRepository, SpecialityRepository>();
        services.AddTransient<IMedicalLicenseStateRepository, MedicalLicenseStateRepository>();
        services.AddTransient<IMedicalDesignationRepository, MedicalDesignationRepository>();
        services.AddTransient<ISystemSettingsRepository, SystemSettingsRepository>();
        services.AddTransient<IEmailTemplateRepository, EmailTemplateRepository>();
        services.AddTransient<IOrganizationRepository, OrganizationRepository>();
        services.AddTransient<IOrganizationTypeRepository, OrganizationTypeRepository>();

        services.AddTransient<IStateRepository, StateRepository>();
        services.AddTransient<ILocationRepository, LocationRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
        services.AddTransient<IActionToModuleRepository, ActionToModuleRepository>();

        services.AddDbContext<AppDbContext>(opt => opt
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddMemoryCache();
        return services;
    }
}
