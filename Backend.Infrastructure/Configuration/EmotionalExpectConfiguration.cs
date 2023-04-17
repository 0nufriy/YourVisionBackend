using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class EmotionalExpectConfiguration : IEntityTypeConfiguration<EmotionalExpect>
    {
        void IEntityTypeConfiguration<EmotionalExpect>.Configure(EntityTypeBuilder<EmotionalExpect> builder)
        {
           builder
                .ToTable(nameof (EmotionalExpect))
                .HasKey(t => t.EmotionalExpectId);
            builder
                .Property(t => t.EmotionalExpectId)
                .IsRequired()
                .HasColumnName("EmotionalExpectId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd(); ;
            builder
                .Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("int");
            builder
               .Property(t => t.AudienceId)
               .IsRequired()
               .HasColumnName("AudienceId")
               .HasColumnType("int");
            builder
                .Property(t => t.Emotional)
                .IsRequired()
                .HasColumnName("Emotional")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.Start)
                .IsRequired()
                .HasColumnName("Start")
                .HasColumnType("int");
            builder
                .Property(t => t.End)
                .IsRequired()
                .HasColumnName("End")
                .HasColumnType("int");
        }
    }
}
