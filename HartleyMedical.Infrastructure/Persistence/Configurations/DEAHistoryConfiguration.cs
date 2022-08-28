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
    public partial class DEAHistoryConfiguration : IEntityTypeConfiguration<DEAHistory>
    {
        public void Configure(EntityTypeBuilder<DEAHistory> entity)
        {
            entity.ToTable("DEAHistory");

            entity.Ignore(e => e.DEAStatus);

            entity.Property(e => e.VerificationBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User)
                .WithMany(p => p.DEAHistories)
                .HasForeignKey(d => d.fk_UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DEAHistory_User");

            entity.HasOne(d => d.CreatedByUser)
               .WithMany(p => p.DEAHistoryCreatedByUser)
               .HasForeignKey(d => d.CreatedBy)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_DEAHistory_CreatedUser");

            entity.HasOne(d => d.ModifiedByUser)
              .WithMany(p => p.DEAHistoryModifiedByUser)
              .HasForeignKey(d => d.ModifiedBy)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_DEAHistory_ModifiedUser");

            OnConfigurePartial(entity);
        }
        partial void OnConfigurePartial(EntityTypeBuilder<DEAHistory> entity);
    }
}
