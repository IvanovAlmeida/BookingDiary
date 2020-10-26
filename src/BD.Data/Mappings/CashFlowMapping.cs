using BD.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Data.Mappings
{
    public class CashFlowMapping : IEntityTypeConfiguration<CashFlow>
    {
        public void Configure(EntityTypeBuilder<CashFlow> builder)
        {
            builder
                .HasKey(p => p.Id);


            builder
                .Property(p => p.Description)
                .HasColumnType("varchar(500)")
                .IsRequired(true);

            builder
                .Property(p => p.Date)
                .HasColumnType("datetime")
                .IsRequired(true);

            builder
                .Property(p => p.Value)
                .HasColumnType("decimal(14,2)")
                .IsRequired(true);
            
            builder
                .HasOne(p => p.Reserve)
                .WithMany(p => p.CashFlows)
                .HasForeignKey(p => p.ReserveId)
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
                .ToTable("CashFlows");
        }
    }
}
