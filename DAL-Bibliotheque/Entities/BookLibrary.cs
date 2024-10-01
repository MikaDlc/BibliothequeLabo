using Commun_Bibliotheque.Entities;

namespace DAL_Bibliotheque.Entities
{
    public class BookLibrary : IBookLibrary
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int LibraryID { get; set; }
        public Library Library { get; set; }
        public int QDispo { get; set; }
    }
}
