namespace EF_Bibliotheque.Entities
{
    internal class Genre
    {
        public string GName { get; set; }
        public List<BookGenre> BookGenres { get; set; }
    }
}
