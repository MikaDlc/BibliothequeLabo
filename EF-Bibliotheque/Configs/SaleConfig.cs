using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.HasKey(s => s.SaleID);
            builder.HasIndex(s => s.SaleID).IsUnique();
            builder.Property(s => s.SaleID).ValueGeneratedOnAdd();
            builder.Property(s => s.Price).IsRequired();
            builder.Property(s => s.DateSale).IsRequired();

            builder.HasOne(s => s.Client).WithMany(c => c.Sales).HasForeignKey(s => s.ClientID).HasConstraintName("FK_Sale_Client");
        }
    }
}
