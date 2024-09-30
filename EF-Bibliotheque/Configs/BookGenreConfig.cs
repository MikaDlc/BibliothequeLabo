using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class BookGenreConfig : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.ToTable("BookGenres");
            builder.HasKey(bg => new { bg.BookID, bg.GName });
            builder.HasOne(bg => bg.Book).WithMany(b => b.BookGenres).HasForeignKey(bg => bg.BookID);
            builder.HasOne(bg => bg.Genre).WithMany(g => g.BookGenres).HasForeignKey(bg => bg.GName);
        }
    }
}
