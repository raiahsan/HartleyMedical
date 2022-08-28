using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Domain.Entities
{
    public partial class Speciality
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserMedicalInfo> PrimaryUserMedicalInfos { get; set; }
        public virtual ICollection<UserMedicalInfo> SecondaryUserMedicalInfos { get; set; }
    }
}
