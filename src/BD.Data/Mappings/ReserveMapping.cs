using BD.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BD.Data.Mappings
{
    public class ReserveMapping : IEntityTypeConfiguration<Reserve>
    {
        public void Configure(EntityTypeBuilder<Reserve> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Entry)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(p => p.Description)
                .HasColumnType("varchar(500)")
                .IsRequired(false);

            builder
                .Property(p => p.DateStart)
                .HasColumnType("datetime");

            builder
                .Property(p => p.DateEnd)
                .HasColumnType("datetime");

            builder
               .Property(p => p.CreatedBy)
               .HasColumnType("int")
               .IsRequired(true);

            builder
               .Property(p => p.UpdatedBy)
               .HasColumnType("int")
               .IsRequired(true);
        }
    }
}
