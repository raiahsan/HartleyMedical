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

#endregion

namespace HartleyMedical.Infrastructure.Repositories.UserRepositories
{
    public class MedicalLicenseStateRepository : GenericRepository<MedicalLicenseState>, IMedicalLicenseStateRepository
    {
        public MedicalLicenseStateRepository(AppDbContext context) : base(context)
        {
        }
    }
}