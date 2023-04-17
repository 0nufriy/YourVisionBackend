using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        void IEntityTypeConfiguration<Report>.Configure(EntityTypeBuilder<Report> builder)
        {
            builder
                .ToTable(nameof(Report))
                .HasKey(t => t.ReportId);
            builder
                .Property(t => t.ReportId)
                .IsRequired()
                .HasColumnName("ID")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.SessionId)
                .IsRequired()
                .HasColumnName("SessionId")
                .HasColumnType("int");
            builder
                .Property(t => t.ReportPath)
                .IsRequired()
                .HasColumnName("ReportPath")
                .HasColumnType("nvarchar(max)");
        }
    }
}
