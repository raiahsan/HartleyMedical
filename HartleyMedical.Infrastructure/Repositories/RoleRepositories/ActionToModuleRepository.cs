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
    public class ActionToModuleRepository : GenericRepository<ActionToModule>, IActionToModuleRepository
    {
        public ActionToModuleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
