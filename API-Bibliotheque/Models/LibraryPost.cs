namespace API_Bibliotheque.Models
{
    public class LibraryPost
    {
        public string Street { get; set; }
        public string NumberH { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; } = "Belgique";
    }
}
