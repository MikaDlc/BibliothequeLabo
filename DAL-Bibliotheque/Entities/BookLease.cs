using Commun_Bibliotheque.Entities;

namespace DAL_Bibliotheque.Entities
{
    public class BookLease : IBookLease
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int LeaseID { get; set; }
        public Lease Lease { get; set; }
    }
}
