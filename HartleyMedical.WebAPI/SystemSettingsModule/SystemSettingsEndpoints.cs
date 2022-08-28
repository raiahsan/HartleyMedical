using HartleyMedical.Application.SystemSettingsModule.Queries.GetSystemSettings;
using HartleyMedical.WebAPI.Helpers;
using HartleyMedical.WebAPI.ModulesRegistration;
using MediatR;
using System.Net;

namespace HartleyMedical.WebAPI.SystemSettingsModule
{
    public partial class SystemSettingsEndpoints : ResponseHelper, IModule
    {
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/SystemSettings/GetSystemSettings", (IMediator _mediator) =>
            {
                return CreateResponse(() =>
                {
                    var response = _mediator.Send(new GetSystemSettingsRequest()).Result;
                    return new SuccessResponseVM
                    {
                        Message = response == null ? "" : "",
                        Result = response,
                        StatusCode = HttpStatusCode.OK,
                        Success = response != null
                    };

                });
            }).WithTags("SystemSettings").RequireAuthorization();
            return endpoints;
        }
      
       }
}
