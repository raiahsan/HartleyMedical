using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Commands.UpdateUserActiveStatus
{
    public class UpdateUserActiveStatusRequest :IRequest<bool>
    {
        public int ID { get; set; }
        public bool Active { get; set; }
    }
}
