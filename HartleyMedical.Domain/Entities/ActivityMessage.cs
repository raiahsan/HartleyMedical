// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public partial class ActivityMessage
    {
        public int ID { get; set; }
        public int fk_ActivityID { get; set; }
        public int fk_ActivityDirectionID { get; set; }
        public string Sender { get; set; }
        public string Reipient { get; set; }
        public bool Sent { get; set; }
        public string Description { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ActivityDirection ActivityDirection { get; set; }
    }
}