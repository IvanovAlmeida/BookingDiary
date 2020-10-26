using BD.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Data.Mappings
{
    public class AppRoleMapping : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Description)
                .HasColumnType("VARCHAR(150)")
                .IsRequired(false);

            builder
                .Property(p => p.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.LastUpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnUpdate();

            builder
                .Property(p => p.DisabledAt)
                .HasColumnType("datetime")
                .IsRequired(false);

            builder
                .HasData(FactoryPermissionSeed());

            builder.ToTable("Roles");
        }

        public List<AppRole> FactoryPermissionSeed()
        {
            return new List<AppRole>()
            {
                new AppRole()
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };
        }
    }
}
