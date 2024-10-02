namespace API_Bibliotheque.Models.Get
{
    public class SaleGet
    {
        public int SaleID { get; set; }
        public double Price { get; set; }
        public DateTime DateSale { get; set; }
        public int ClientID { get; set; }
    }
}
