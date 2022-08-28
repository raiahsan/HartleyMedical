using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.RoleModule.Commands.UpdateRoleActiveStatus
{
    public class UpdateRoleActiveStatusRequest : IRequest<bool>
    {
        public int ID { get; set; }
        public bool Active { get; set; }
    }
}
