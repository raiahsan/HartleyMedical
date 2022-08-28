﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using HartleyMedical.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HartleyMedical.Infrastructure.Persistence.Configurations
{
    public partial class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> entity)
        {
            entity.ToTable("ExceptionLog");

            entity.Property(e => e.Method)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RequestUrl)
                .HasMaxLength(100)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ExceptionLog> entity);
    }
}