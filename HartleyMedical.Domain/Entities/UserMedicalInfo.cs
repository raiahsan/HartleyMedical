using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Domain.Entities
{
    public partial class UserMedicalInfo : BaseModel
    {
        public UserMedicalInfo()
        {
            UserMedicalInfoCreatedByUser = new HashSet<UserMedicalInfo>();
            UserMedicalInfoModifiedByUser = new HashSet<UserMedicalInfo>();
        }
        public int ID { get; set; }
        public string NPINumber { get; set; }
        public string MedicalLicenseNumber { get; set; }
        public int? fk_MedicalDesignationID { get; set; }
        public int? fk_MedicalLicenseStateID { get; set; }
        public int? fk_PrimarySpecialityID { get; set; }
        public int? fk_SecondarySpecialityID { get; set; }
        public int fk_UserID { get; set; }

        public virtual MedicalDesignation MedicalDesignation { get; set; }
        public virtual MedicalLicenseState MedicalLicenseState { get; set; }
        public virtual Speciality PrimarySpeciality { get; set; }
        public virtual Speciality SecondarySpeciality { get; set; }
        public virtual User User { get; set; }
        public virtual UserMedicalInfo CreatedByUser { get; set; }
        public virtual UserMedicalInfo ModifiedByUser { get; set; }
        public virtual ICollection<UserMedicalInfo> UserMedicalInfoCreatedByUser { get; set; }
        public virtual ICollection<UserMedicalInfo> UserMedicalInfoModifiedByUser { get; set; }
    }
}
