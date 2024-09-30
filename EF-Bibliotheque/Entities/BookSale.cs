namespace EF_Bibliotheque.Entities
{
    internal class BookSale
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int SaleID { get; set; }
        public Sale Sale { get; set; }
    }
}
