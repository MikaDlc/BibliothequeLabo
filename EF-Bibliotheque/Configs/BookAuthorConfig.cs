using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("BookAuthors");
            builder.HasKey(ba => new { ba.BookID, ba.AuthorID });
            builder.HasOne(ba => ba.Book).WithMany(b => b.BookAuthors).HasForeignKey(ba => ba.BookID);
            builder.HasOne(ba => ba.Author).WithMany(a => a.BookAuthors).HasForeignKey(ba => ba.AuthorID);
        }
    }
}
