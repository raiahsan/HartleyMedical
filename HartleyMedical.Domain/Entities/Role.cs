
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public partial class Role : BaseModel
    {
        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserToOrganizations = new HashSet<UserToOrganizationRole>();
        }

        public int ID { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int fk_UserTypeID { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserToOrganizationRole> UserToOrganizations { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User ModifiedByUser { get; set; }
    }
}