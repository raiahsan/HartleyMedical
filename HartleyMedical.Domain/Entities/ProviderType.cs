// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public partial class ProviderType
    {
        public ProviderType()
        {
            PatientProviders = new HashSet<PatientProvider>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PatientProvider> PatientProviders { get; set; }
    }
}