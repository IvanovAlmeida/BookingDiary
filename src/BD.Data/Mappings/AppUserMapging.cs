using System;
using BD.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BD.Data.Mappings
{
    public class AppUserMapging : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Email)
                .HasColumnType("varchar(120)")
                .IsRequired(true);

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

            builder.HasData(FactoryAppUsersSeed());

            builder
                .ToTable("Users");
        }

        public AppUser[] FactoryAppUsersSeed()
        {
            var name = "Admin";
            var email = "admin@admin.com";

            AppUser[] users = { 
                new AppUser
                {
                    Id = 1,
                    Name = name,
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Teste@123"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            return users;
        }
    }
}
