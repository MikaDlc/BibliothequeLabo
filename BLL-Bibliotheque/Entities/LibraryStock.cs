namespace BLL_Bibliotheque.Entities
{
    public class LibraryStock
    {
        public int LibraryID { get; set; }
        public string Street { get; set; }
        public string NumberH { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Stock { get; set; }
    }
}
