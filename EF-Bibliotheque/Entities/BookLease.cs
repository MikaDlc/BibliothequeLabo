namespace EF_Bibliotheque.Entities
{
    internal class BookLease
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int LeaseID { get; set; }
        public Lease Lease { get; set; }
    }
}
