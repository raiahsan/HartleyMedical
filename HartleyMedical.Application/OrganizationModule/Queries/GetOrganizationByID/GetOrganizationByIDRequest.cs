using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Queries.GetOrganizationByID
{
    public class GetOrganizationByIDRequest :IRequest<GetOrganizationByIDResponse>
    {
        public int ID { get; set; }
        public GetOrganizationByIDRequest(int id)
        {
            ID = id;  
        }
    }
}
