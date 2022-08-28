using FluentValidation;
using HartleyMedical.Application.Common.CustomValidators;
using HartleyMedical.Application.Common.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Commands.UpsertUser
{
    public class UpsertUserRequest : IRequest<UpsertUserResponse>
    {
        public int ID { get; set; }
        public bool IsPrescriberInstance { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserTypeID { get; set; }
        public bool TwoFAEnabled { get; set; }
        public bool Active { get; set; }
        public string DEANumber { get; set; }
        public string DEACertificateUrl { get; set; }
        public IFormFile DEACertificateFile { get; set; }
        public string PrescriberSignatureUrl { get; set; }
        public IFormFile PrescriberSignatureFile { get; set; }
        public List<UserToDEAHistoryResponse> UserToDEAHistoryDetails { get; set; }
        public UserToMedicalInfoResponse UserToMedicalInfoDetails { get; set; }
        public List<UserToOrganizationRoleResponse> UserToOrganizationDetails { get; set; }

        public static ValueTask<UpsertUserRequest?> BindAsync(HttpContext context, ParameterInfo parameter)
        {
            var FormData = context.Request.Form;
            var result = new UpsertUserRequest
            {
                ID = String.IsNullOrEmpty(FormData["ID"]) ? 0 : Convert.ToInt32(FormData["ID"]),
                FirstName = FormData["Name"],
                DEACertificateFile = FormData.Files["DEACertificateFile"],
                PrescriberSignatureFile = FormData.Files["PrescriberSignaturefile"],
                UserToMedicalInfoDetails = JsonConvert.DeserializeObject<UserToMedicalInfoResponse>(FormData["UserToMedicalInfoDetails"]),
                UserToOrganizationDetails = JsonConvert.DeserializeObject<List<UserToOrganizationRoleResponse>>(FormData["UserToOrganizationDetails"])
            };
            return ValueTask.FromResult<UpsertUserRequest?>(result);
        }
    }

    public class UserToDEAHistoryResponse
    {
        public int ID { get; set; }
        public string DEAStatus { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string VerificationBy { get; set; }
    }

    public class UserToMedicalInfoResponse
    {
        public int ID { get; set; }
        public string NPINumber { get; set; }
        public int? MedicalDesignationID { get; set; }
        public string MedicalDesignationName { get; set; }
        public string MedicalLicenseNumber { get; set; }
        public int? MedicalLicenseStateID { get; set; }
        public string MedicalLicenseStateName { get; set; }
        public int? PrimarySpecialityID { get; set; }
        public string PrimarySpecialityName { get; set; }
        public int? SecondarySpecialityID { get; set; }
        public string SecondarySpecialityName { get; set; }
    }

    public class UserToOrganizationRoleResponse
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public int OrganizationTypeID { get; set; }
        public string OrganizationTypeName { get; set; }
    }

    public class CreateUserRequestValidator : AbstractValidator<UpsertUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("FirstName is required");

            RuleFor(c => c.LastName).NotEmpty().WithMessage("LastName is required");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is invalid");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required")
                .IsPhoneNumber().WithMessage("PhoneNumber is invalid");

            RuleFor(c => c.UserTypeID).NotEmpty().WithMessage("UserTypeID is required");
        }
    }
}
