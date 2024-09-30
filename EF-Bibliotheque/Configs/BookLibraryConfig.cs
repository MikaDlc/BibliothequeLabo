using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class BookLibraryConfig : IEntityTypeConfiguration<BookLibrary>
    {
        public void Configure(EntityTypeBuilder<BookLibrary> builder)
        {
            builder.ToTable("BookLibrary");
            builder.HasKey(bl => new { bl.BookID, bl.LibraryID });
            builder.HasOne(bl => bl.Book).WithMany(b => b.BookLibraries).HasForeignKey(bl => bl.BookID);
            builder.HasOne(bl => bl.Library).WithMany(l => l.BookLibraries).HasForeignKey(bl => bl.LibraryID);
            builder.Property(bl => bl.QDispo).IsRequired();
            builder.HasIndex(bl => new { bl.BookID, bl.LibraryID }).IsUnique();
        }
    }
}
