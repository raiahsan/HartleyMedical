using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganization
{
    public class GetAllOrganizationsRequest : IRequest<List<GetAllOrganizationsResponse>>
    {
        public int? OrganizationTypeID { get; set; }
        public bool? Active { get; set; }
    }
}
