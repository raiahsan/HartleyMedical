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
    public class MedicalInfoRepository : GenericRepository<UserMedicalInfo>, IMedicalInfoRepository
    {
        public MedicalInfoRepository(AppDbContext context) : base(context)
        {
        }

        public UserMedicalInfo GetUserMedicalInfoByID(int UserMedicalInfoId)
        {
            return _context.UserMedicalInfos.Where(c => c.ID == UserMedicalInfoId).FirstOrDefault();
        }
    }
}
