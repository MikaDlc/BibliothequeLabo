namespace EF_Bibliotheque.Entities
{
    public class Genre
    {
        public string GName { get; set; }
        public List<BookGenre> BookGenres { get; set; }
    }
}
