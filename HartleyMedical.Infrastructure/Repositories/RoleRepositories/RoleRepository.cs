using HartleyMedical.Application.Common.Helpers;
using HartleyMedical.Application.RepositoryInterfaces.IRoleRepositories;
using HartleyMedical.Application.RoleModule.Models;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Repositories.RoleRepositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
        public override Task<Role> Get(int id)
        {
            return Task.FromResult(_context.Roles.Where(c => c.ID == id && !c.IsDeleted).FirstOrDefault());
        }
        public override async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Roles.Where(c => !c.IsDeleted).ToListAsync();
        }
        public override IList<Role> GetMany(Func<Role, bool> where, params Expression<Func<Role, object>>[] includes)
        {
            var query = _context.Roles.Where(c => !c.IsDeleted).AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).ToList();
        }
        public override Role GetFirst(Func<Role, bool> where, params Expression<Func<Role, object>>[] includes)
        {
            var query = _context.Roles.Where(c => !c.IsDeleted).AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).FirstOrDefault();
        }
        public List<RolePermissionsDto> GetPermissionsByRoleID(int? roleID, bool? isAllowed = null)
        {
            var result = _context.ExecuteSqlStoredProcedure("sp_GetPermissionsByRoleID", new List<SqlParameter>
            {
                new SqlParameter("@roleID", roleID ??Convert.DBNull),
                new SqlParameter("@isAllowed", isAllowed ??Convert.DBNull)
            });
            return JSONSerializerHelper.Deserialize<List<RolePermissionsDto>>(result.Tables[0]);
        }
    }
}
