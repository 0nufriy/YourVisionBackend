using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class AudienceConfiguration : IEntityTypeConfiguration<Audience>
    {
        void IEntityTypeConfiguration<Audience>.Configure(EntityTypeBuilder<Audience> builder)
        {
            builder
                .ToTable(nameof(Audience))
                .HasKey(t => t.AudienceId);
            builder
                .Property(t => t.AudienceId)
                .IsRequired()
                .HasColumnName("AudienceId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
               .Property(t => t.Age)
               .IsRequired()
               .HasColumnName("Age")
               .HasColumnType("int");
            builder
               .Property(t => t.Sex)
               .IsRequired()
               .HasColumnName("Sex")
               .HasColumnType("bit");
        }
    }
}
