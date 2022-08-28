using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Models
{
    public class RolePermissionsDto
    {
        public int ActionToModuleID { get; set; }
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public int? RolePermissionID { get; set; }
        public bool IsAllowed { get; set; }
    }
}
