using API_Bibliotheque.Models.Get;

namespace API_Bibliotheque.Models.GetDetails
{
    public class LibraryDetails
    {
        public int LibraryID { get; set; }
        public string Street { get; set; }
        public string NumberH { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<BookGet> Books { get; set; }
    }
}
