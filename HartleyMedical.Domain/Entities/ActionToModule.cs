﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HartleyMedical.Domain.Entities
{
    public class ActionToModule
    {
        public ActionToModule()
        {
            RolePermissions = new HashSet<RolePermission>();
        }
        public int ID { get; set; }
        public int fk_ActionID { get; set; }
        public int fk_ModuleID { get; set; }
        public virtual Action Action { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}