using API_Bibliotheque.Models.Get;

namespace API_Bibliotheque.Models.GetDetails
{
    public class LeaseDetails
    {
        public int LeaseId { get; set; }
        public DateTime LeaseDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ClientGet Client { get; set; }
        public double? Price { get; set; }
        public List<BookGet> Books { get; set; }
    }
}
