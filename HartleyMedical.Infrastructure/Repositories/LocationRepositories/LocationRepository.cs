using HartleyMedical.Application.RepositoryInterfaces.ILocationRepositories;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Repositories.LocationRepositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }
        public override Task<Location> Get(int id)
        {
            return Task.FromResult(_context.Locations.Where(c => c.ID == id && !c.IsDeleted).FirstOrDefault());
        }

        public override async Task<IEnumerable<Location>> GetAll()
        {
            return await _context.Locations.Where(c => !c.IsDeleted).ToListAsync();
        }
        public override IList<Location> GetMany(Func<Location, bool> where, params Expression<Func<Location, object>>[] includes)
        {
            var query = _context.Locations.Where(c => !c.IsDeleted).AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).ToList();
        }

        public override Location GetFirst(Func<Location, bool> where, params Expression<Func<Location, object>>[] includes)
        {
            var query = _context.Locations.Where(c => !c.IsDeleted).AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).FirstOrDefault();
        }
    }
}
