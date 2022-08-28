using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.LocationModule.Queries.GetLocationByID
{
    public class GetLocationByIDResponse
    {
        public int ID { get; set; }
        public string LocationName { get; set; }
        public int OrganizationID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
    }
}
