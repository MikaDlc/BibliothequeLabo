using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class BookLeaseConfig : IEntityTypeConfiguration<BookLease>
    {
        public void Configure(EntityTypeBuilder<BookLease> builder)
        {
            builder.ToTable("BookLeases");
            builder.HasKey(bl => new { bl.BookID, bl.LeaseID });
            builder.HasOne(bl => bl.Book).WithMany(b => b.BookLeases).HasForeignKey(bl => bl.BookID);
            builder.HasOne(bl => bl.Lease).WithMany(l => l.BookLeases).HasForeignKey(bl => bl.LeaseID);
        }
    }
}
