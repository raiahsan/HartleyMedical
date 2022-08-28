
using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.RoleModule.Models;

namespace HartleyMedical.Application.UserModule.Queries.GetMedicalInfoLookups
{
    public class GetMedicalInfoLookupsResponse
    {
        public List<LookupDto> Specialities { get; set; }
        public List<LookupDto> MedicalDesignations { get; set; }
        public List<LookupDto> MedicalLicenseStates { get; set; }

    }

}
