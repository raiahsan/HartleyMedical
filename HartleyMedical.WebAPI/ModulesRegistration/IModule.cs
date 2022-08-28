namespace HartleyMedical.WebAPI.ModulesRegistration;

public interface IModule
{
    //IServiceCollection RegisterModule(IServiceCollection builder);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
