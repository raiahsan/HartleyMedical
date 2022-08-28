using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Queries.GetAllLoctaions
{
    public class GetAllLocationsRequest : IRequest<List<GetAllLocationsResponse>>
    {
        public bool? Active { get; set; }
    }
}
