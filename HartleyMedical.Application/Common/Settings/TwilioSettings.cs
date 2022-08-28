namespace HartleyMedical.Application.Common.Settings
{
    public class TwilioSettings
    {
        /*----JWT accessToken Settings----*/
        public const string key = "TwilioSettings";
        public string AccountSID { get; set; }
        public string AuthToken { get; set; }
        public string SenderNumber { get; set; }
        public bool IsSMSEnabled { get; set; }
    }
}