﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public partial class EmailTemplate : BaseModel
    {
        public int ID { get; set; }
        public int fk_EmailType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Active { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual EmailType EmailType { get; set; }
    }
}