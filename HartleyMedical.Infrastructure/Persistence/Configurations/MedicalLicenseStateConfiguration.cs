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
    public partial class MedicalLicenseStateConfiguration : IEntityTypeConfiguration<MedicalLicenseState>
    {
        public void Configure(EntityTypeBuilder<MedicalLicenseState> entity)
        {
            entity.ToTable("MedicalLicenseState");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MedicalLicenseState> entity);
    }
}
