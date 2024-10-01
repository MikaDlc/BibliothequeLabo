namespace EF_Bibliotheque.Entities
{
    public class BookGenre
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public string GName { get; set; }
        public Genre Genre { get; set; }
    }
}
