using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        void IEntityTypeConfiguration<Profile>.Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .ToTable(nameof(Profile))
                .HasKey(t => t.ProfileId);
            builder
                .Property(t => t.ProfileId)
                .IsRequired()
                .HasColumnName("ProfileId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("nvarchar(256)");
            builder
                .Property(t => t.password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("nvarchar(256)");
            builder
                .Property(t => t.PhoneNumber)
                .IsRequired()
                .HasColumnName("PhoneNumber")
                .HasColumnType("nvarchar(256)");
            builder
                .Property(t => t.Role)
                .IsRequired()
                .HasColumnName("Role")
                .HasColumnType("nvarchar(max)");

        }

    }
}
