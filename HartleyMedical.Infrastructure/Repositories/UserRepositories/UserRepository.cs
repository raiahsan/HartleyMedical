#region Imports
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using HartleyMedical.Application.Common.Helpers;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using System.Linq.Expressions;
using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.UserModule.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using HartleyMedical.Application.UserModule.Queries.GetAllUsers;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByDEANumber;

#endregion

namespace HartleyMedical.Infrastructure.Repositories.UserRepositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<User> GetUserByEmail(string email)
        {
            try
            {
                return _context.Users.Where(u => u.Email == email && !u.IsDeleted).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _context.Users
                .Include(c => c.UserToOrganizationRoles)
                //.ThenInclude(c => c.Role)
                .Where(c => c.Email == email && c.Active && !c.IsDeleted)
                .FirstOrDefaultAsync();
            return user != null && user.Password.VerifyWithBCrypt(password) ? user : null;
        }
        public User GetUserByID(int userID)
        {
            return _context.Users
                .Include(c => c.UserToOrganizationRoles)
                    .ThenInclude(c => c.Role)
                .Where(c => c.ID == userID  && !c.IsDeleted).FirstOrDefault();
        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users
                 .Include(c => c.UserToOrganizationRoles)
                     .ThenInclude(c => c.Role)
                .Include(c => c.UserType)
                .Where(c => !c.IsDeleted).ToListAsync();
        }

        public override Task<User> Get(int id)
        {
            return _context.Users.Where(c => c.ID == id && !c.IsDeleted).FirstOrDefaultAsync();
        }

        public override IList<User> GetMany(Func<User, bool> where, params Expression<Func<User, object>>[] includes)
        {
            var query = _context.Users.Where(c => !c.IsDeleted).AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).ToList();
        }

        public override User GetFirst(Func<User, bool> where, params Expression<Func<User, object>>[] includes)
        {
            var query = _context.Users.Where(c => !c.IsDeleted).AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).FirstOrDefault();
        }

        public RecordSet<GetAllUsersResponse> GetUsers(GetAllUsersRequest getAllUsersRequest)
        {
            var result = _context.ExecuteSqlStoredProcedure("sp_GetUsers", new List<SqlParameter>
            {
                new SqlParameter("@search",getAllUsersRequest.Search ?? Convert.DBNull),
                new SqlParameter("@pageSize", getAllUsersRequest.PageSize),
                new SqlParameter("@pageIndex", getAllUsersRequest.PageIndex),
                new SqlParameter("@active",getAllUsersRequest.Active ?? Convert.DBNull),
                new SqlParameter("@sortColumn", !String.IsNullOrWhiteSpace(getAllUsersRequest.SortColumn) ? getAllUsersRequest.SortColumn : default),
                new SqlParameter("@sortDirection", !String.IsNullOrWhiteSpace(getAllUsersRequest.SortDirection) ? getAllUsersRequest.SortDirection : default),
            });
            var totalRecords = Convert.ToInt32(result.Tables[0].Rows[0][0]);
            var users = JSONSerializerHelper.Deserialize<List<GetAllUsersResponse>>(result.Tables[1]);
            return new RecordSet<GetAllUsersResponse>
            {
                Items = users,
                TotalRows = totalRecords,
            };
        }
        public GetUserDetailsByIDResponse GetUserDetailsByID(GetUserDetailsByIDRequest request)
        {
            var UserDetails = GetUserDetailsFromDB(request.UserID, "");
            return UserDetails;
        }

        public GetUserDetailsByIDResponse GetUserDetailsByDEANumber(string DEANumber)
        {
            var UserDetails = GetUserDetailsFromDB(0, DEANumber);
            return UserDetails;

        }

        private GetUserDetailsByIDResponse GetUserDetailsFromDB(int UserId, string DEANumber)
        {
            
            
            var result = _context.ExecuteSqlStoredProcedure("sp_GetUserByID_DEA", new List<SqlParameter>
            {
                new SqlParameter("@userID", UserId),
                new SqlParameter("@DEANumber", DEANumber)
            });

            var userDetails = JSONSerializerHelper.Deserialize<List<GetUserDetailsByIDResponse>>(result.Tables[0]).FirstOrDefault();
            if (userDetails != null)
            {
                userDetails.UserToOrganizationDetails = JSONSerializerHelper.Deserialize<List<UserToOrganizationRoleResponse>>(result.Tables[1]);
                userDetails.UserToDEAHistoryDetails = JSONSerializerHelper.Deserialize<List<UserToDEAHistoryResponse>>(result.Tables[2]);
                userDetails.UserToMedicalInfoDetails = JSONSerializerHelper.Deserialize<List<UserToMedicalInfoResponse>>(result.Tables[3]).FirstOrDefault();
            }
            return userDetails;
        }
    }
}