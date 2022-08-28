namespace HartleyMedical.Application.Common.Settings
{
    public class AppSettings
    {
        /*----JWT accessToken Settings----*/
        public const string key = "AppSettings";
        public string Secret { get; set; }
        public int? JwtTokenExpireInMinute { get; set; }
        public string APIKey { get; set; }
        public string VerificationToken { get; set; }
        public string UIBaseURL { get; set; }
        public string APIBaseURL { get; set; }
    }
}