using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Domain.Entities
{
    public partial class MedicalLicenseState
    {
        public int ID { get; set; }
        //public string State { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<UserMedicalInfo> UserMedicalInfos { get; set; }
    }
}
