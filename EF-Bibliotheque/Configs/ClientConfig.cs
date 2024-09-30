using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder) 
        {
            builder.ToTable("Client");
            builder.HasKey(c => c.ClientID);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Street).IsRequired().HasMaxLength(50);
            builder.Property(c => c.NumberH).IsRequired().HasMaxLength(10);
            builder.Property(c => c.PostalCode).IsRequired().HasMaxLength(10);
            builder.Property(c => c.City).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Country).IsRequired().HasMaxLength(50);
        }
    }
}
