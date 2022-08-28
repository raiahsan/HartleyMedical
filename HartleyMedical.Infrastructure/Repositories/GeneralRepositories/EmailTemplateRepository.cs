using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Repositories.GeneralRepositories
{
    internal class EmailTemplateRepository : GenericRepository<EmailTemplate>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(AppDbContext context) : base(context)
        {
        }

        public EmailTemplate GetEmailTemplateByName(string name)
        {
            return _context.EmailTemplates.Where(c => c.Name == name && c.Active).AsNoTracking().FirstOrDefault();
        }
    }
}