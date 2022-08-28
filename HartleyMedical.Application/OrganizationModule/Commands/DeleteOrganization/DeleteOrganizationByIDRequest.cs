using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Commands.DeleteOrganization
{
    public class DeleteOrganizationByIDRequest :IRequest<bool>
    {
        public int ID { get; set; }
        public DeleteOrganizationByIDRequest(int id)
        {
            ID = id;
        }
    }
}
