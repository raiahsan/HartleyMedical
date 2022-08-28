
using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.UserModule.Models;
using HartleyMedical.Application.UserModule.Queries.GetAllUsers;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByDEANumber;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID;
using HartleyMedical.Domain.Entities;

namespace HartleyMedical.Application.RepositoryInterfaces.IUserRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Authenticate(string email, string password);
        Task<User> GetUserByEmail(string email);
        RecordSet<GetAllUsersResponse> GetUsers(GetAllUsersRequest getAllUsersRequest);
        GetUserDetailsByIDResponse GetUserDetailsByID(GetUserDetailsByIDRequest request);
        GetUserDetailsByIDResponse GetUserDetailsByDEANumber(string DEANumber);
        User GetUserByID(int UserID);
    }
}