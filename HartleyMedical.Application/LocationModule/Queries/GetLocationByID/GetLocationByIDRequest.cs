using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Queries.GetLocationByID
{
    public class GetLocationByIDRequest :IRequest<GetLocationByIDResponse>
    {
        public int ID { get; set; }
        public GetLocationByIDRequest(int id)
        {
            ID = id;
        }
    }
}
