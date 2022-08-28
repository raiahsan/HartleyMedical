using HartleyMedical.Application.GeneralModule.Queries.GetAllStates;
using HartleyMedical.Application.OrganizationModule.Commands.CreateOrganization;
using HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganizationTypes;
using HartleyMedical.WebAPI.Helpers;
using HartleyMedical.WebAPI.ModulesRegistration;
using MediatR;
using System.Net;

namespace HartleyMedical.WebAPI.GeneralModule;
public class GeneralEndpoints : ResponseHelper, IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("General/GetAllStates", (IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetAllStatesRequest()).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("General").RequireAuthorization();

        return endpoints;
    }
}
