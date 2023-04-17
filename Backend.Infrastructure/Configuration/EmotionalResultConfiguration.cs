using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class EmotionalResultConfiguration : IEntityTypeConfiguration<EmotionalResult>
    {
        void IEntityTypeConfiguration<EmotionalResult>.Configure(EntityTypeBuilder<EmotionalResult> builder)
        {
            builder
                .ToTable(nameof(EmotionalResult))
                .HasKey(t => t.EmotionalResultId);
            builder
                .Property(t => t.EmotionalResultId)
                .IsRequired()
                .HasColumnName("EmotionalResultId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("int");
            builder
                .Property(t => t.PersonId)
                .IsRequired()
                .HasColumnName("PersonId")
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
