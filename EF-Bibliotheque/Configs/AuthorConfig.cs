using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.AuthorID);
            builder.Property(a => a.AuthorID).ValueGeneratedOnAdd();
            builder.HasIndex(a => a.AuthorID).IsUnique();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => new { a.Name, a.FirstName }).IsUnique();
            builder.HasMany(a => a.Books).WithMany(b => b.Authors);
        }
    }
}
