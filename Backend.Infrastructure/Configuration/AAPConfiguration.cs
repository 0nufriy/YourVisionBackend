using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class AAPConfiguration : IEntityTypeConfiguration<AAP>
    {
       void IEntityTypeConfiguration<AAP>.Configure(EntityTypeBuilder<AAP> builder)
        {
            builder
                .ToTable(nameof(AAP))
                .HasKey(t => new { t.AudiencePackId, t.AudienceId });
            builder
                .Property(t => t.AudienceId)
                .IsRequired()
                .HasColumnName("AudienceId")
                .HasColumnType("int");
            builder
                .Property(t => t.AudiencePackId)
                .IsRequired()
                .HasColumnName("AudiencePackId")
                .HasColumnType("int");
            builder
                .Property(t => t.AudienceCount)
                .IsRequired()
                .HasColumnName("AudienceCount")
                .HasColumnType("int");
        }
    }
}
