using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.ExternalDependencyInterfaces
{
    public interface ISMSService
    {
        bool SendSMS(string phoneNumber, string message);
    }
}
