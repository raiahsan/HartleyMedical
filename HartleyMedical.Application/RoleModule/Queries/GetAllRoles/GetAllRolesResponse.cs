namespace HartleyMedical.Application.RoleModule.Queries.GetAllRoles
{
    public class GetAllRolesResponse
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public int ActiveUsers { get; set; }
        public int InActiveUsers { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public int UserTypeID { get; set; }
    }
}
