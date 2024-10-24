using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.BookID);
            builder.Property(b => b.BookID).ValueGeneratedOnAdd();
            builder.HasIndex(b => b.BookID).IsUnique();
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Edition).IsRequired();
            builder.Property(b => b.EditionDate).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.HasIndex(b => new { b.Title, b.Edition });
            builder.HasMany(b => b.Authors).WithMany(a => a.Books);
            builder.HasMany(b => b.Genres).WithMany(g => g.Books);
            builder.HasMany(b => b.Sales).WithMany(s => s.Books);
            builder.HasMany(b => b.Leases).WithMany(l => l.Books);
        }
    }
}
