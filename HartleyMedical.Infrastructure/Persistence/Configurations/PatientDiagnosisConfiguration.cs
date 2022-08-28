﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using HartleyMedical.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HartleyMedical.Infrastructure.Persistence.Configurations
{
    public partial class PatientDiagnosisConfiguration : IEntityTypeConfiguration<PatientDiagnosis>
    {
        public void Configure(EntityTypeBuilder<PatientDiagnosis> entity)
        {
            entity.ToTable("PatientDiagnosis");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.Sequence)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ShortDescription)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.PatientDiagnosisCreatedByUser)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDiagnosis_User");

            entity.HasOne(d => d.ModifiedByUser)
                .WithMany(p => p.PatientDiagnosisModifiedByUser)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDiagnosis_User1");

            entity.HasOne(d => d.Diagnosis)
                .WithMany(p => p.PatientDiagnoses)
                .HasForeignKey(d => d.fk_DiagnosisID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDiagnosis_Diagnosis");

            entity.HasOne(d => d.Patient)
                .WithMany(p => p.PatientDiagnoses)
                .HasForeignKey(d => d.fk_PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDiagnosis_Patient");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PatientDiagnosis> entity);
    }
}
