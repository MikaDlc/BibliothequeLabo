using API_Bibliotheque.Models.Get;

namespace API_Bibliotheque.Models.GetDetails
{
    public class ClientDetails
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string FirsName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string NumberH { get; set; }
        public List<SaleGet> Sales { get; set; }
        public List<LeaseGet> Leases { get; set; }
    }
}
