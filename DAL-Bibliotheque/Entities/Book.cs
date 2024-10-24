using Commun_Bibliotheque.Entities;

namespace DAL_Bibliotheque.Entities
{
    public class Book : IBook
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public int EditionDate { get; set; }
        public double Price { get; set; }
        public List<BookLibrary> BookLibraries { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
