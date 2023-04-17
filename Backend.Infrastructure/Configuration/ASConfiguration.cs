using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class ASConfiguration : IEntityTypeConfiguration<AudienceSession>
    {
       void IEntityTypeConfiguration<AudienceSession>.Configure(EntityTypeBuilder<AudienceSession> builder)
        {
            builder
                .ToTable(nameof(AudienceSession))
                .HasKey(t => new { t.AudiencePackId, t.SessionId });
            
            builder
                .Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("int");
            builder
                .Property(t => t.AudiencePackId)
                .IsRequired()
                .HasColumnName("AudiencePackId")
                .HasColumnType("int");
            builder
                .Property(t => t.AudiencePackCount)
                .IsRequired()
                .HasColumnName("AudiencePackCount")
                .HasColumnType("int");
        }
    }
}
