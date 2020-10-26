using BD.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BD.Data.Mappings
{
    public class ReserveItemMapping : IEntityTypeConfiguration<ReserveItem>
    {
        public void Configure(EntityTypeBuilder<ReserveItem> builder)
        {
            builder
                .HasKey(p => p.IdReserveItem);

            builder
                .HasOne(ri => ri.Reserve)
                .WithMany(r => r.ReserveItem)
                .HasForeignKey(ri => ri.ReserveId);

            builder
                .HasOne(ri => ri.Item)
                .WithMany(i => i.ReserveItems)
                .HasForeignKey(ri => ri.ItemId);

            builder
                .Property(p => p.Quantity)
                .HasColumnType("int");

            builder
                .Property(p => p.PricePerUnit)
                .HasColumnType("decimal(18,2)");
        }
    }
}