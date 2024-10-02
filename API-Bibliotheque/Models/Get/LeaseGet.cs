namespace API_Bibliotheque.Models.Get
{
    public class LeaseGet
    {
        public int LeaseId { get; set; }
        public DateTime LeaseDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int ClientId { get; set; }
        public double? Price { get; set; }
    }
}
