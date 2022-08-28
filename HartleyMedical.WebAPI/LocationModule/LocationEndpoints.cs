using HartleyMedical.Application.GeneralModule.Queries.GetAllStates;
using HartleyMedical.Application.LocationModule.Commands.DeleteLocationByID;
using HartleyMedical.Application.LocationModule.Commands.UpdateLocationActiveStatus;
using HartleyMedical.Application.LocationModule.Commands.UpsertLocation;
using HartleyMedical.Application.LocationModule.Queries.GetAllLoctaions;
using HartleyMedical.Application.LocationModule.Queries.GetLocationByID;
using HartleyMedical.Application.OrganizationModule.Commands.CreateOrganization;
using HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganizationTypes;
using HartleyMedical.WebAPI.Helpers;
using HartleyMedical.WebAPI.ModulesRegistration;
using MediatR;
using System.Net;

namespace HartleyMedical.WebAPI.LocationModule;
public class LocationEndpoints : ResponseHelper, IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("Location/UpsertLocation", (UpsertLocationRequest request, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(request).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Location upserted successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Location").RequireAuthorization();

        endpoints.MapGet("Location/GetAllLocations", (bool? active, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetAllLocationsRequest { Active = active }).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Location").RequireAuthorization();

        endpoints.MapGet("Location/GetLocationByID/{id}", (int id, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetLocationByIDRequest(id)).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? $"Location with ID '{id}' not found" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Location").RequireAuthorization();

        endpoints.MapPost("Location/DeleteLocationByID/{id}", (int id, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new DeleteLocationByIDRequest(id)).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "Location deleted successfully" : "Something went wrong",
                    Result = null,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("Location").RequireAuthorization();

        endpoints.MapPost("Location/UpdateLocationActiveStatus", (UpdateLocationActiveStatusRequest updateLocationActiveStatusRequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(updateLocationActiveStatusRequest).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "LocationActiveStatus updated successfully" : "Something went wrong",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("Location").RequireAuthorization();


        return endpoints;
    }
}
