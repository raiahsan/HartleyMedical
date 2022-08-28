using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Commands.DeleteLocationByID
{
    public class DeleteLocationByIDRequest :IRequest<bool>
    {
        public int ID { get; set; }
        public DeleteLocationByIDRequest(int id)
        {
            ID = id;
        }
    }
}
