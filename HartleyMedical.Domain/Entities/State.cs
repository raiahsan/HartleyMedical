﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public partial class State
    {
        public State()
        {
            PatientAddresses = new HashSet<PatientAddress>();
            PatientContacts = new HashSet<PatientContact>();
            PatientPayorEligibilityDetails = new HashSet<PatientPayorEligibilityDetail>();
            PatientPayors = new HashSet<PatientPayor>();
            Locations = new HashSet<Location>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PatientAddress> PatientAddresses { get; set; }
        public virtual ICollection<PatientContact> PatientContacts { get; set; }
        public virtual ICollection<PatientPayorEligibilityDetail> PatientPayorEligibilityDetails { get; set; }
        public virtual ICollection<PatientPayor> PatientPayors { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}