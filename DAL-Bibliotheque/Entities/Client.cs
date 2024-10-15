using Commun_Bibliotheque.Entities;

namespace DAL_Bibliotheque.Entities
{
    public class Client : IClient
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string NumberH { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public bool IsAdmin { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Lease> Leases { get; set; }

    }
}
