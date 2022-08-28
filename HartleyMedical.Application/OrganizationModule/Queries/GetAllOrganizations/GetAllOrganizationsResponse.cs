using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganization
{
    public class GetAllOrganizationsResponse
    {
        public int ID { get; set; }
        public string FacilityName { get; set; }
        public int OrganizationTypeID { get; set; }
        public string GroupNPI { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public bool Active { get; set; }
    }
}
