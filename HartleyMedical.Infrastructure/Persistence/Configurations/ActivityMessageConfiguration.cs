﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using HartleyMedical.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace HartleyMedical.Infrastructure.Persistence.Configurations
{
    public partial class ActivityMessageConfiguration : IEntityTypeConfiguration<ActivityMessage>
    {
        public void Configure(EntityTypeBuilder<ActivityMessage> entity)
        {
            entity.ToTable("ActivityMessage");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.Reipient)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Sender)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Activity)
                .WithMany(p => p.ActivityMessages)
                .HasForeignKey(d => d.fk_ActivityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_Activity");

            entity.HasOne(d => d.ActivityDirection)
                .WithMany(p => p.ActivityMessages)
                .HasForeignKey(d => d.fk_ActivityDirectionID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Message_ActivityDirection");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ActivityMessage> entity);
    }
}