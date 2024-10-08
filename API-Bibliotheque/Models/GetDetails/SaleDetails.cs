using API_Bibliotheque.Models.Get;

namespace API_Bibliotheque.Models.GetDetails
{
    public class SaleDetails
    {
        public int SaleID { get; set; }
        public double Price { get; set; }
        public DateTime DateSale { get; set; }
        public ClientGet Client { get; set; }
        public List<BookGet> Books { get; set; }
    }
}
