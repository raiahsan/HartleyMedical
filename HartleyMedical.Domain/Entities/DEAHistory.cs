using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Domain.Entities
{
    public partial class DEAHistory : BaseModel
    {
        public DEAHistory()
        {
            DEAHistoryCreatedByUser = new HashSet<DEAHistory>();
            DEAHistoryModifiedByUser = new HashSet<DEAHistory>();
            //UserToDEAHistories = new HashSet<UserToDEAHistory>();
        }
        public int ID { get; set; }
        public bool IsExpired { get; set; }
        public string DEAStatus { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string VerificationBy { get; set; }
        public int fk_UserID { get; set; }

        public virtual User User { get; set; }
        public virtual DEAHistory CreatedByUser { get; set; }
        public virtual DEAHistory ModifiedByUser { get; set; }

        public virtual ICollection<DEAHistory> DEAHistoryCreatedByUser { get; set; }
        public virtual ICollection<DEAHistory> DEAHistoryModifiedByUser { get; set; }
        //public virtual ICollection<UserToDEAHistory> UserToDEAHistories { get; set; }
    }
}
