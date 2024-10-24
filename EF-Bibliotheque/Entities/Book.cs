namespace EF_Bibliotheque.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public int EditionDate { get; set; }
        public double Price { get; set; }
        public List<BookLibrary> BookLibraries { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Lease> Leases { get; set; }
    }
}
