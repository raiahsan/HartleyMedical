using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Repositories.UserRepositories
{
    public class UserToOrganizationRoleRepository : GenericRepository<UserToOrganizationRole>, IUserToOrganizationRoleRepository
    {
        public UserToOrganizationRoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
