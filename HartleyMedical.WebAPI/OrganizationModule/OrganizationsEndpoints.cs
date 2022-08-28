using HartleyMedical.Application.OrganizationModule.Commands.CreateOrganization;
using HartleyMedical.Application.OrganizationModule.Commands.DeleteOrganization;
using HartleyMedical.Application.OrganizationModule.Commands.UpdateOrganizationActiveStatus;
using HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganization;
using HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganizationTypes;
using HartleyMedical.Application.OrganizationModule.Queries.GetOrganizationByID;
using HartleyMedical.WebAPI.Helpers;
using HartleyMedical.WebAPI.ModulesRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HartleyMedical.WebAPI.OrganizationModule;
public partial class OrganizationEndpoints : ResponseHelper, IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("Organization/UpsertOrganization", (UpsertOrganizationRequest createOrganization, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(createOrganization).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Organization upserted successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Organization").RequireAuthorization();

        endpoints.MapGet("Organization/GetAllOrganizationTypes", (IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetAllOrganizationTypesRequest { }).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Organization").RequireAuthorization();

        endpoints.MapGet("Organization/GetAllOrganizations", (int? organizationTypeID,bool ? active, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetAllOrganizationsRequest { OrganizationTypeID=organizationTypeID, Active = active }).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Organization").RequireAuthorization();

        endpoints.MapGet("Organization/GetOrganizationByID/{id}", (int id, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetOrganizationByIDRequest(id)).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? $"Organization with ID '{id}' not found" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Organization").RequireAuthorization();

        endpoints.MapPost("Organization/DeleteOrganizationByID/{id}", (int id, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new DeleteOrganizationByIDRequest(id)).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "Organization deleted successfully" : "Something went wrong",
                    Result = null,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("Organization").RequireAuthorization();

        endpoints.MapPost("Organization/UpdateOrganizationActiveStatus", (UpdateOrganizationActiveStatusRequest organizationActiveStatusRequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(organizationActiveStatusRequest).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "OrganizationActiveStatus updated successfully" : "Something went wrong",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("Organization").RequireAuthorization();


        return endpoints;
    }
}
