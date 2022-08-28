using HartleyMedical.Application.AuthModule.Commands.ForgotPassword;
using HartleyMedical.Application.AuthModule.Commands.ResendTwoFACode;
using HartleyMedical.Application.AuthModule.Commands.ResetPassword;
using HartleyMedical.Application.AuthModule.Commands.ValidateResetPasswordLink;
using HartleyMedical.Application.AuthModule.Commands.ValidateTwoFACode;
using HartleyMedical.Application.AuthModule.Queries.LoginQuery;
using HartleyMedical.WebAPI.Helpers;
using HartleyMedical.WebAPI.ModulesRegistration;
using MediatR;
using System.Net;

namespace HartleyMedical.WebAPI.AuthModule;

public partial class AuthModule : ResponseHelper, IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/Auth/Authenticate", (LoginQueryRequest loginQueryRequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(loginQueryRequest).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Invalid credentials" : "success",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };

            });
        }).WithTags("Auth");

        endpoints.MapPost("/Auth/ValidateTwoFACode", (ValidateTwoFACodeRequest validateTwoFARequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(validateTwoFARequest).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Invalid code" : validateTwoFARequest.IsLoginRequest ? "Login Successful" : "Valid code",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Auth");

        endpoints.MapPost("/Auth/ValidateResetPasswordLink", (ValidateResetPasswordLinkRequest validateResetPasswordLinkRequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(validateResetPasswordLinkRequest).Result;
                return new SuccessResponseVM
                {
                    Message = response != null ? "Valid Link" : "Invalid link",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Auth");

        endpoints.MapPost("/Auth/ResetPassword", (ResetPasswordRequest resetPasswordRequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(resetPasswordRequest).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "Password reset successfully" : "Something went wrong",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("Auth");

        endpoints.MapPost("/Auth/ForgotPassword", (ForgotPasswordRequest forgotPasswordRequest, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(forgotPasswordRequest).Result;
                return new SuccessResponseVM
                {
                    Message = response ? "Recovery email sent successfully. Please follow the instructions provided in the email to reset your password." : "Email not found",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response
                };
            });
        }).WithTags("Auth");

        endpoints.MapPost("/Auth/ResendTwoFACode", (ResendTwoFACodeRequest request, IMediator _mediator) =>
        {
            return CreateResponse(() =>
            {
                var response = _mediator.Send(request).Result;
                return new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Successful",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                };
            });
        }).WithTags("Auth");

        return endpoints;
    }
}