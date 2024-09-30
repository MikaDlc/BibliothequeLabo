using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class BookSaleConfig : IEntityTypeConfiguration<BookSale>
    {
        public void Configure(EntityTypeBuilder<BookSale> builder)
        {
            builder.ToTable("BookSales");
            builder.HasKey(bs => new { bs.BookID, bs.SaleID });
            builder.HasOne(bs => bs.Book).WithMany(b => b.BookSales).HasForeignKey(bs => bs.BookID);
            builder.HasOne(bs => bs.Sale).WithMany(s => s.BookSales).HasForeignKey(bs => bs.SaleID);
        }
    }
}
