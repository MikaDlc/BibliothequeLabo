using Commun_Bibliotheque.Entities;

namespace DAL_Bibliotheque.Entities
{
    public class Sale : ISale
    {
        public int SaleID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateSale { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public List<BookSale> BookSales { get; set; }
    }
}
