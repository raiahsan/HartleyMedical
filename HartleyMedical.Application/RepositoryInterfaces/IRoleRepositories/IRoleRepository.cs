using HartleyMedical.Application.RoleModule.Models;
using HartleyMedical.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        List<RolePermissionsDto> GetPermissionsByRoleID(int? roleID, bool? isAllowed = null);
    }
}
