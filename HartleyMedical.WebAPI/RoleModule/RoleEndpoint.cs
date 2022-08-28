using HartleyMedical.Application.RoleModule.Commands.DeleteRole;
using HartleyMedical.Application.RoleModule.Commands.UpdateRoleActiveStatus;
using HartleyMedical.Application.RoleModule.Commands.UpsertRole;
using HartleyMedical.Application.RoleModule.Queries.GetAllRoles;
using HartleyMedical.Application.RoleModule.Queries.GetPermissionsByRoleID;
using HartleyMedical.Application.RoleModule.Queries.GetUserPermissionsByRoleID;
using HartleyMedical.WebAPI.Helpers;
using HartleyMedical.WebAPI.ModulesRegistration;
using MediatR;
using Polly;
using System.Net;
using System.Web.Http;
using Twilio.Jwt.Taskrouter;

namespace HartleyMedical.WebAPI.RoleModule;

public partial class RoleEndpoint : ResponseHelper, IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("Role/GetAllRoles", [Authorize(Roles = "Clinical Staff")] (int? userTypeID,bool ? active, IMediator _mediator) =>
         {
             return CreateResponse(() =>
             {
                 var response = _mediator.Send(new GetAllRolesRequest { UserTypeID= userTypeID, Active = active }).Result;
                 return new SuccessResponseVM
                 {
                     Message = response == null ? "Something went wrong" : "Records fetched successfully",
                     Result = response,
                     StatusCode = HttpStatusCode.OK,
                     Success = response != null
                 };
             });
         }).WithTags("Role").RequireAuthorization();

        endpoints.MapPost("Role/UpsertRole", (UpsertRoleRequest upsertRole, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(upsertRole).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Role upserted successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Role").RequireAuthorization();

        endpoints.MapPost("Role/UpdateRoleActiveStatus", (UpdateRoleActiveStatusRequest updateRoleActiveStatus, IMediator _mediator) =>
         {
             return CreateResponse(() =>
             {
                 var response = _mediator.Send(updateRoleActiveStatus).Result;
                 return new SuccessResponseVM
                 {
                     Message = response ? "RoleActiveStatus updated successfully" : "Something went wrong",
                     Result = response,
                     StatusCode = HttpStatusCode.OK,
                     Success = response
                 };
             });
         }).WithTags("Role").RequireAuthorization();

        endpoints.MapGet("Role/GetPermissionsByRoleID", ( int? roleID, IMediator _mediator) =>
        {
           
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetPermissionsByRoleIDRequest { RoleID = roleID}).Result;
                return new SuccessResponseVM
                {
                    Message = response != null ? "Records fetched successfully" : "Something went wrong",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Role").RequireAuthorization();

        endpoints.MapGet("Role/GetUserPermissionsByRoleID", (int? roleID, IMediator _mediator) =>
        {

            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetUserPermissionsByRoleIDRequest { RoleID = roleID }).Result;
                return new SuccessResponseVM
                {
                    Message = response != null ? "Records fetched successfully" : "Something went wrong",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Role").RequireAuthorization();

        endpoints.MapPost("Role/DeleteRoleByID/{id}", (int id, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new DeleteRoleByIDRequest(id)).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "Role deleted successfully" : "Something went wrong",
                    Result = null,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("Role").RequireAuthorization();
        return endpoints;
    }
}

