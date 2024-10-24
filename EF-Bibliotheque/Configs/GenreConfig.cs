using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasKey(g => g.GName);
            builder.Property(g => g.GName).IsRequired().HasMaxLength(50).ValueGeneratedOnAdd();
            builder.HasIndex(g => g.GName).IsUnique();
            builder.HasMany(g => g.Books).WithMany(b => b.Genres);
        }
    }
}
