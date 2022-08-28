﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public partial class Location : BaseModel
    {
        public Location()
        {
            Patients = new HashSet<Patient>();
            ProviderLocations = new HashSet<ProviderLocation>();
        }

        public int ID { get; set; }
        public string LocationName { get; set; }
        public int fk_FacilityID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int fk_StateID { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Organization Facility { get; set; }
        public virtual State State { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<ProviderLocation> ProviderLocations { get; set; }
    }
}