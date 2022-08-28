﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using HartleyMedical.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HartleyMedical.Infrastructure.Persistence.Configurations
{
    public partial class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> entity)
        {
            entity.ToTable("UserType");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<UserType> entity);
    }
}