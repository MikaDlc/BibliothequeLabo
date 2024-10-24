namespace EF_Bibliotheque.Entities
{
    public class Genre
    {
        public string GName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
