using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class LeaseConfig : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> builder)
        {
            builder.ToTable("Leases");
            builder.HasKey(l => l.LeaseID);
            builder.HasIndex(l => l.LeaseID).IsUnique();
            builder.Property(l => l.LeaseID).ValueGeneratedOnAdd();
            builder.Property(l => l.LeaseDate).IsRequired();
            builder.Property(l => l.ReturnDate).IsRequired(false);
            builder.Property(l => l.Price).IsRequired(false);

            builder.HasOne(l => l.Client).WithMany(c => c.Leases).HasForeignKey(l => l.ClientID).HasConstraintName("FK_Lease_Client");
        }
    }
}
