using API_Bibliotheque.Models.Get;

namespace API_Bibliotheque.Models.GetDetails
{
    public class BookDetails
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public int EditionDate { get; set; }
        public double Price { get; set; }
        public List<AuthorGet> Authors { get; set; }
        public List<GenreGet> Genres { get; set; }
        public List<LibraryStockDetails> Libraries { get; set; }
    }
}
