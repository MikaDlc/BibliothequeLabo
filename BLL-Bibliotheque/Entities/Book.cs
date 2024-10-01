using Commun_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Entities
{
    public class Book : IBook
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public int EditionDate { get; set; }
        public double Price { get; set; }
        public List<BookLibrary> BookLibraries { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        public List<BookSale> BookSales { get; set; }
        public List<BookLease> BookLeases { get; set; }
    }
}
