using Commun_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Entities
{
    public class BookGenre : IBookGenre
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public string GName { get; set; }
        public Genre Genre { get; set; }
    }
}
