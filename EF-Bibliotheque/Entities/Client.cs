namespace EF_Bibliotheque.Entities
{
    internal class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string NumberH { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Authentification Authentification { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Lease> Leases { get; set; }

    }
}
