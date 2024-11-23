using Commun_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Entities
{
    public class LibraryStock : ILibrary
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
