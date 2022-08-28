using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Commands.UpdateLocationActiveStatus
{
    public class UpdateLocationActiveStatusRequest : IRequest<bool>
    {
        public int ID { get; set; }
        public bool Active { get; set; }
    }
}
