using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Bibliotheque.Configs
{
    internal class AuthentificationConfig : IEntityTypeConfiguration<Authentification>
    {
        public void Configure(EntityTypeBuilder<Authentification> builder)
        {
            builder.ToTable("Authentifications");
            builder.HasKey(a => a.AuthentificationID);
            builder.Property(a => a.AuthentificationID).ValueGeneratedOnAdd();
            builder.HasIndex(a => a.AuthentificationID).IsUnique();
            builder.Property(a => a.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(a => a.Email).IsUnique();
            builder.Property(a => a.Passwd).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Salage).IsRequired().HasMaxLength(100);

            builder.HasOne(a => a.Client).WithOne(c => c.Authentification).HasForeignKey<Authentification>(a => a.ClientID).HasConstraintName("FK_Client_Authentification");
        }
    }
}
