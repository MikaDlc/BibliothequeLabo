namespace API_Bibliotheque.Models.Get
{
    public class BookGet
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public int EditionDate { get; set; }
        public double Price { get; set; }
    }
}
