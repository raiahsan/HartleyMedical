﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public partial class ActivityStatus
    {
        public ActivityStatus()
        {
            ActivityTasks = new HashSet<ActivityTask>();
        }

        public int ID { get; set; }
        public string Status { get; set; }
        public int Active { get; set; }

        public virtual ICollection<ActivityTask> ActivityTasks { get; set; }
    }
}