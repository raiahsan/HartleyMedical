﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public partial class ActivityEmail
    {
        public int ID { get; set; }
        public int fk_ActivityID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        public string Recipients { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }

        public virtual Activity Activity { get; set; }
    }
}