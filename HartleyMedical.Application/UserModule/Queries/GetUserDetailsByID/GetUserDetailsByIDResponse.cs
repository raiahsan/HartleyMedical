
using HartleyMedical.Application.RoleModule.Models;
using Microsoft.AspNetCore.Http;

namespace HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID
{
    public class GetUserDetailsByIDResponse
    {
        public int ID { get; set; }
        public bool IsPrescriberInstance { get; set; }
        public int UserTypeID { get; set; }
        public int BranchID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool TwoFAEnabled { get; set; }
        public string Prefix { get; set; }
        public string DEANumber { get; set; }
        public bool IsDEANumberVerified { get; set; }
        public string DEACertificateUrl { get; set; }
        public IFormFile DEACertificateFile { get; set; }
        public string PrescriberSignatureUrl { get; set; }
        public IFormFile PrescriberSignaturefile { get; set; }
        public List<UserToOrganizationRoleResponse> UserToOrganizationDetails { get; set; }
        public List<UserToDEAHistoryResponse> UserToDEAHistoryDetails { get; set; }
        public UserToMedicalInfoResponse UserToMedicalInfoDetails { get; set; }
    }
    public class UserToOrganizationRoleResponse {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public int OrganizationTypeID { get; set; }
        public string OrganizationTypeName { get; set; }
        public bool IsCurrent { get; set; }
        public List<ModuleToActionsDto> ModuleToActions { get; set; }
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
}
