using HartleyMedical.Application.Common.Settings;
using HartleyMedical.Application.ExternalDependencyInterfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HartleyMedical.Infrastructure.ExternalDependenciesImplementation
{
    public class TwilioSMSService : ISMSService
    {
        private TwilioSettings _twilioSettings;
        public TwilioSMSService(IOptions<TwilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
            TwilioClient.Init(_twilioSettings.AccountSID, _twilioSettings.AuthToken);
        }
        public bool SendSMS(string phoneNumber, string message)
        {
            try
            {
                MessageResource.Create(
                    body: message,
                    from: new PhoneNumber(_twilioSettings.SenderNumber),
                    to: new PhoneNumber(phoneNumber)
                );
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
