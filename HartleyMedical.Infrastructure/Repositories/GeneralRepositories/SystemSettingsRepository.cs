using HartleyMedical.Application.RepositoryInterfaces;
using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace HartleyMedical.Infrastructure.Repositories.GeneralRepositories
{
    public class SystemSettingsRepository : GenericRepository<SystemSetting>, ISystemSettingsRepository
    {
        public SystemSettingsRepository(AppDbContext context) : base(context)
        {
        }
        public List<SystemSetting> GetSystemSettings()
        {
               return _context.SystemSettings.ToList();
        }
    }
}
