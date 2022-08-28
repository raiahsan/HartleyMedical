using HartleyMedical.Application.RepositoryInterfaces.IOrganizationRepositories;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Repositories.OrganizationRepositories
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(AppDbContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Organization>> GetAll()
        {
            return await _context.Organizations
                 .Include(c => c.OrganizationType)
                 .Where(c => !c.IsDeleted).ToListAsync();
        }

        public override Task<Organization> Get(int Id)
        {
            return Task.FromResult(_context.Organizations
                .Include(c => c.OrganizationType)
                .Where(c => c.ID == Id && !c.IsDeleted).FirstOrDefault());
        }
        public override IList<Organization> GetMany(Func<Organization, bool> where, params Expression<Func<Organization, object>>[] includes)
        {
            var query = _context.Organizations.Where(c => !c.IsDeleted).AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).ToList();
        }

        public override Organization GetFirst(Func<Organization, bool> where, params Expression<Func<Organization, object>>[] includes)
        {
            var query = _context.Organizations.Where(c => !c.IsDeleted).AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).FirstOrDefault();
        }
    }
}
