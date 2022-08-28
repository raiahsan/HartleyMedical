using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Commands.UpdateOrganizationActiveStatus
{
    public class UpdateOrganizationActiveStatusRequest : IRequest<bool>
    {
        public int ID { get; set; }
        public bool Active { get; set; }
    }
}
