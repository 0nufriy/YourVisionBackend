using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class AudiencePackConfiguration : IEntityTypeConfiguration<AudiencePack>
    {
        void IEntityTypeConfiguration<AudiencePack>.Configure(EntityTypeBuilder<AudiencePack> builder)
        {
            builder
               .ToTable(nameof(AudiencePack))
               .HasKey(t => t.AudiencePackId);
            builder
                .Property(t => t.AudiencePackId)
                .IsRequired()
                .HasColumnName("AudiencePackId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.AudiencePackName)
                .IsRequired()
                .HasColumnName("AudiencePackName")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("int");
        }
    }
}
