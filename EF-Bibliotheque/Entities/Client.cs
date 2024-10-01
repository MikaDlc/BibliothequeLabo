namespace EF_Bibliotheque.Entities
{
    public class Client
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
        public string Salage { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Lease> Leases { get; set; }

    }
}
