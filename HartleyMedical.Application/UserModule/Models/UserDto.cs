
using HartleyMedical.Application.RoleModule.Models;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID;

namespace HartleyMedical.Application.UserModule.Models
{
    public class UserDto
    {
        //public int ID { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public bool Active { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Role { get; set; }
        //public int? RoleID { get; set; }
        //public int UserTypeID { get; set; }
        ////public List<RolePermissionsDto> RolePermissions { get; set; }
        //public List<ModuleToActionsDto> ModuleToActions { get; set; }

        public int ID { get; set; }
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
        public List<UserToOrganizationRoleResponse> UserToOrganizationDetails { get; set; }

    }

}