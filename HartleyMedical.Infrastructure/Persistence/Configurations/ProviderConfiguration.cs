// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using HartleyMedical.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HartleyMedical.Infrastructure.Persistence.Configurations
{
    public partial class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> entity)
        {
            entity.ToTable("Provider");

            entity.Property(e => e.Address1)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CommercialNumber)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.DEAExpiryDate).HasColumnType("datetime");

            entity.Property(e => e.DEANumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.DegreeDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.DoctorGroup).IsUnicode(false);

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FaxNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IMSRxerID)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LicenseExpiryDate).HasColumnType("datetime");

            entity.Property(e => e.Location)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.MedicalID)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.NPINumber)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Note).HasColumnType("text");

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Specialty)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.StateMedicaidID)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Suffix)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.TaxonomyCode)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.UPIN)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.ParentProvider)
                .WithMany(p => p.ChildProviders)
                .HasForeignKey(d => d.fk_ParentProviderID)
                .HasConstraintName("FK_Provider_Provider");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Provider> entity);
    }
}
