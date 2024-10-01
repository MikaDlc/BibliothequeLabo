using Commun_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Entities
{
    public class BookSale : IBookSale
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int SaleID { get; set; }
        public Sale Sale { get; set; }
    }
}
