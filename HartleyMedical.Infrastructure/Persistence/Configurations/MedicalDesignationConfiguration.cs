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
    public partial class MedicalDesignationConfiguration : IEntityTypeConfiguration<MedicalDesignation>
    {
        public void Configure(EntityTypeBuilder<MedicalDesignation> entity)
        {
            entity.ToTable("MedicalDesignation");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }
        partial void OnConfigurePartial(EntityTypeBuilder<MedicalDesignation> entity);
    }
}
