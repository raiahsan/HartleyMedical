﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using HartleyMedical.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HartleyMedical.Infrastructure.Persistence.Configurations
{
    public partial class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.ToTable("Location");

            entity.Property(e => e.AddressLine1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.AddressLine2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.LocationName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Facility)
                .WithMany(p => p.Locations)
                .HasForeignKey(d => d.fk_FacilityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_Facility");

            entity.HasOne(d => d.State)
                .WithMany(p => p.Locations)
                .HasForeignKey(d => d.fk_StateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_State");

            entity.HasOne(d => d.CreatedByUser)
              .WithMany(p => p.LocationsCreatedByUser)
              .HasForeignKey(d => d.CreatedBy)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Location_CreatedUser");

            entity.HasOne(d => d.ModifiedByUser)
              .WithMany(p => p.LocationsModifiedByUser)
              .HasForeignKey(d => d.ModifiedBy)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Location_ModifiedUser");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Location> entity);
    }
}