﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using HartleyMedical.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HartleyMedical.Infrastructure.Persistence.Configurations
{
    public partial class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> entity)
        {
            entity.ToTable("Organization");

            entity.Property(e => e.FacilityName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.GroupNPI)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.TaxIdentificationNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationType)
                .WithMany(p => p.Organizations)
                .HasForeignKey(d => d.fk_OrganizationTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organization_OrganizationType");

            entity.HasOne(d => d.CreatedByUser)
               .WithMany(p => p.OrganizationsCreatedByUser)
               .HasForeignKey(d => d.CreatedBy)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Organization_CreatedUser");

            entity.HasOne(d => d.ModifiedByUser)
              .WithMany(p => p.OrganizationsModifiedByUser)
              .HasForeignKey(d => d.ModifiedBy)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Organization_ModifiedUser");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Organization> entity);
    }
}
