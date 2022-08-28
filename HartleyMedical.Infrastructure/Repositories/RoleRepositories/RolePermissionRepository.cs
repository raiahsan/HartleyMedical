using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Repositories.RoleRepositories
{
    public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
