using Application.ServiceInterfaces.IUserServices;
using HartleyMedical.Application.UserModule.Commands.DeleteUser;
using HartleyMedical.Application.UserModule.Commands.UpdateUserActiveStatus;
using HartleyMedical.Application.UserModule.Commands.UpsertUser;
using HartleyMedical.Application.UserModule.Queries.GetAllUsers;
using HartleyMedical.Application.UserModule.Queries.GetAllUserTypes;
using HartleyMedical.Application.UserModule.Queries.GetMedicalInfoLookups;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByDEANumber;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID;
using HartleyMedical.WebAPI.Helpers;
using HartleyMedical.WebAPI.ModulesRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;

namespace HartleyMedical.WebAPI.UserModule;

public partial class UsersModule : ResponseHelper, IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        //endpoints.MapGet("/Users", () =>
        //{

        //}).WithTags("Users");

        endpoints.MapPost("/User/UpsertUser", (UpsertUserRequest createUserRequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(createUserRequest).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "UpsertUser successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };

            });
        }).Accepts<UpsertUserRequest>("multipart/form-data").WithTags("User").RequireAuthorization();

        endpoints.MapGet("/User/GetAllUserTypes", (IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetAllUserTypesRequest { }).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };

            });
        }).WithTags("User").RequireAuthorization();

        endpoints.MapGet("/User/GetAllUsers", (int PageIndex, string Search, int PageSize, string SortColumn, string SortDirection, bool? Active, IMediator _mediator) =>
         {
             return CreateResponse(() =>
             {
                 var response = _mediator.Send(new GetAllUsersRequest
                 {
                     PageIndex = PageIndex,
                     PageSize = PageSize,
                     Search = Search,
                     SortColumn = SortColumn,
                     SortDirection = SortDirection,
                     Active = Active
                 }).Result;
                 var paginationSet = new PaginationSet<GetAllUsersResponse>
                 {
                     Items = response.Items,
                     TotalRows = response.TotalRows
                 };
                 return new SuccessResponseVM
                 {
                     Message = response == null ? "Something went wrong" : "Records fetched successfully",
                     Result = response,
                     StatusCode = HttpStatusCode.OK,
                     Success = response != null
                 };
             });
         }).WithTags("User").RequireAuthorization();

        endpoints.MapGet("/User/GetUserDetailsByID", (int userID, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetUserDetailsByIDRequest
                {
                    UserID = userID
                }).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("User").RequireAuthorization();

        endpoints.MapGet("/User/GetUserDetailsByDEANumber", (string dEANumber, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetUserDetailsByDEANumberRequest
                {
                    DEANumber = dEANumber
                }).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("User").RequireAuthorization();

        endpoints.MapPost("User/DeleteUserByID/{id}", (int id, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new DeleteUserByIDRequest(id)).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "User deleted successfully" : "Something went wrong",
                    Result = null,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("User").RequireAuthorization();

        endpoints.MapPost("User/UpdateUserActiveStatus", (UpdateUserActiveStatusRequest updateUserActiveStatusRequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(updateUserActiveStatusRequest).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "UserActiveStatus updated successfully" : "Something went wrong",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("User").RequireAuthorization();

        endpoints.MapGet("/User/GetMedicalInfoLookups", (IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(new GetMedicalInfoLookupsRequest { }).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Records fetched successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };

            });
        }).WithTags("User").RequireAuthorization();
        return endpoints;
    }
}