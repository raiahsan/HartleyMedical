using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Repositories.OrganizationRepositories
{
    public class OrganizationTypeRepository : GenericRepository<OrganizationType>, IOrganizationTypeRepository
    {
        public OrganizationTypeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
