using EF_Bibliotheque.Configs;
using EF_Bibliotheque.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Bibliotheque
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookLease> BookLeases { get; set; }
        public DbSet<BookLibrary> BookLibraries { get; set; }
        public DbSet<BookSale> BookSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bibliotheque;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new BookAuthorConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new BookGenreConfig());
            modelBuilder.ApplyConfiguration(new BookLeaseConfig());
            modelBuilder.ApplyConfiguration(new BookLibraryConfig());
            modelBuilder.ApplyConfiguration(new BookSaleConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new LeaseConfig());
            modelBuilder.ApplyConfiguration(new LibraryConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
        }
    }
}
