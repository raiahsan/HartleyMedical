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
    public class DEAHistoryRepository : GenericRepository<DEAHistory>, IDEAHistoryRepository
    {
        public DEAHistoryRepository(AppDbContext context) : base(context)
        {
        }

        public DEAHistory GetDEAHistoryByID(int DEAHistoryID)
        {
            return _context.DEAHistories.Where(c => c.ID == DEAHistoryID).FirstOrDefault();
        }
    }
}
