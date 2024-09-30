namespace EF_Bibliotheque.Entities
{
    internal class Library
    {
        public int LibraryID { get; set; }
        public string Street { get; set; }
        public string NumberH { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<BookLibrary> BookLibraries { get; set; }
    }
}
