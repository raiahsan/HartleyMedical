using HartleyMedical.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RepositoryInterfaces.IUserRepositories
{
    public interface IDEAHistoryRepository : IGenericRepository<DEAHistory>
    {
        DEAHistory GetDEAHistoryByID(int DEAHistoryID);
    }
}
