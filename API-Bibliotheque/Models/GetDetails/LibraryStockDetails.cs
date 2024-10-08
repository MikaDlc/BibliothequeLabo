namespace API_Bibliotheque.Models.GetDetails
{
    public class LibraryStockDetails
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
