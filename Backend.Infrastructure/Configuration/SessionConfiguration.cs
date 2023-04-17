using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        void IEntityTypeConfiguration<Session>.Configure(EntityTypeBuilder<Session> builder)
        {
            builder
                .ToTable(nameof(Session))
                .HasKey(t => t.SessionId);
            builder
                .Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.Datetime)
                .IsRequired()
                .HasColumnName("Datetime")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.ProfileId)
                .HasColumnName("ProfileId")
                .HasColumnType("int");
            builder
                .Property(t => t.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.DurationMinute)
                .IsRequired()
                .HasColumnName("DurationMinute")
                .HasColumnType("int");
            builder
               .Property(t => t.Location)
               .IsRequired()
               .HasColumnName("Location")
               .HasColumnType("nvarchar(max)");
        }
    }
}
