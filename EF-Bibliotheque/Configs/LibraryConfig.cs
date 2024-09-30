using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class LibraryConfig : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable("Library");
            builder.HasKey(l => l.LibraryID);
            builder.HasIndex(l => l.LibraryID).IsUnique();
            builder.Property(l => l.LibraryID).ValueGeneratedOnAdd();
            builder.Property(l => l.Street).HasMaxLength(100).IsRequired();
            builder.Property(l => l.NumberH).HasMaxLength(10).IsRequired();
            builder.Property(l => l.PostalCode).HasMaxLength(10).IsRequired();
            builder.Property(l => l.City).HasMaxLength(50).IsRequired();
            builder.Property(l => l.Country).HasMaxLength(50).IsRequired();
        }
    }
}
