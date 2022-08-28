using HartleyMedical.Application.RepositoryInterfaces.IStateRepositories;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Repositories.StateRepositories
{
    internal class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(AppDbContext context) : base(context)
        {
        }
    }
}
