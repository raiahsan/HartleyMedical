using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.Common.Settings
{
    public class AzureSettings
    {
        public const string key = "AzureSettings";
        public const string DEACertificates = "deacertificates";
        public const string Signatures = "signatures";
        public const string ProfilePictures = "profilepictures";
        public string AccountConnectionString { get; set; }
    }
}
