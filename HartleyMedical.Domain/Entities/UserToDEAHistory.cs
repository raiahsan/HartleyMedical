using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Domain.Entities
{
    public partial class UserToDEAHistory
    {
        public int ID { get; set; }
        public int fk_UserID { get; set; }
        public int fk_DEAHistoryID { get; set; }
        public virtual User User { get; set; }
        public virtual DEAHistory DEAHistory { get; set; }

    }
}
