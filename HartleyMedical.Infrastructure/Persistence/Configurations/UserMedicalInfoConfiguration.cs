using HartleyMedical.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Infrastructure.Persistence.Configurations
{
    public partial class UserMedicalInfoConfiguration : IEntityTypeConfiguration<UserMedicalInfo>
    {
        public void Configure(EntityTypeBuilder<UserMedicalInfo> entity)
        {
            entity.ToTable("UserMedicalInfo");

            entity.Property(e => e.MedicalLicenseNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MedicalDesignation)
                .WithMany(p => p.UserMedicalInfos)
                .HasForeignKey(d => d.fk_MedicalDesignationID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMedicalInfo_MedicalDesignation");

            entity.HasOne(d => d.MedicalLicenseState)
                .WithMany(p => p.UserMedicalInfos)
                .HasForeignKey(d => d.fk_MedicalLicenseStateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMedicalInfo_MedicalLicenseState");

            entity.HasOne(d => d.PrimarySpeciality)
                .WithMany(p => p.PrimaryUserMedicalInfos)
                .HasForeignKey(d => d.fk_PrimarySpecialityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMedicalInfo_Speciality_Primary");

            entity.HasOne(d => d.SecondarySpeciality)
                .WithMany(p => p.SecondaryUserMedicalInfos)
                .HasForeignKey(d => d.fk_SecondarySpecialityID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMedicalInfo_Speciality_Secondary");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserMedicalInfos)
                .HasForeignKey(d => d.fk_UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMedicalInfo_User");

            entity.HasOne(d => d.CreatedByUser)
               .WithMany(p => p.UserMedicalInfoCreatedByUser)
               .HasForeignKey(d => d.CreatedBy)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_UserMedicalInfo_CreatedUser");

            entity.HasOne(d => d.ModifiedByUser)
              .WithMany(p => p.UserMedicalInfoModifiedByUser)
              .HasForeignKey(d => d.ModifiedBy)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_UserMedicalInfo_ModifiedUser");

            OnConfigurePartial(entity);
        }
        partial void OnConfigurePartial(EntityTypeBuilder<UserMedicalInfo> entity);
    }
}
