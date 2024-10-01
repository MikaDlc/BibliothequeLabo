using Commun_Bibliotheque.Entities;

namespace DAL_Bibliotheque.Entities
{
    public class BookAuthor : IBookAuthor
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
