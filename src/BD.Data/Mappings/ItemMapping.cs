using BD.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Data.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(180)")
                .IsRequired(true);

            builder
                .Property(p => p.Quantity)
                .HasColumnType("int")
                .IsRequired(true);

            builder
                .Property(p => p.Price)
                .IsRequired(true)
                .HasColumnType("decimal(14,2)");

            builder
                .Property(p => p.Description)
                .HasColumnType("varchar(1000)")
                .IsRequired(false);

            builder
               .Property(p => p.CreatedAt);

            builder
                .Property(p => p.CreatedBy)
                .HasColumnType("int")
                .IsRequired(true);

            builder
                .Property(p => p.LastUpdatedAt);

            builder
                .Property(p => p.UpdatedBy)
                .HasColumnType("int")
                .IsRequired(true);

            builder
                .Property(p => p.DisabledAt)
                .IsRequired(false);

            builder
                .ToTable("Items");
        }
    }
}
