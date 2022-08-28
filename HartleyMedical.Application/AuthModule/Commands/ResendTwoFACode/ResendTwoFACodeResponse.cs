using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.AuthModule.Commands.ResendTwoFACode
{
    public class ResendTwoFACodeResponse
    {
        public int UserID { get; set; }
        public string Code { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
