using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Queries.GetPermissionsByRoleID
{
    public class GetPermissionsByRoleIDResponse
    {
        public GetPermissionsByRoleIDResponse()
        {
            Actions = new List<GetActionPermissions>();
        }
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public bool IsAllowed { get; set; }
        public List<GetActionPermissions> Actions { get; set; }
    }

    public class GetActionPermissions
    {
        public int ActionToModuleID { get; set; }
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public int? RolePermissionID { get; set; }
        public bool IsAllowed { get; set; }
    }
}
