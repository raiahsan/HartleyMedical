using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Queries.LoginQuery
{
    public class LoginQueryResponse
    {
        public int UserID { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
