
using HartleyMedical.Application.UserModule.Models;

namespace HartleyMedical.Application.UserModule.Queries.GetAllUsers
{
    public class GetAllUsersResponse
    {
        public int Id { get; set; }
        public int UserTypeID { get; set; }
        public int BranchID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserTypeName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool TwoFAEnabled { get; set; }
        public string Prefix { get; set; }
        public string DEANumber { get; set; }
        public bool IsDEANumberVerified { get; set; }
    }
}
