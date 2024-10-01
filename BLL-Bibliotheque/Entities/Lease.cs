using Commun_Bibliotheque.Entities;
using System;
using System.Collections.Generic;

namespace BLL_Bibliotheque.Entities
{
    public class Lease : ILease
    {
        public int LeaseID { get; set; }
        public DateTime LeaseDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double? Price { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public List<BookLease> BookLeases { get; set; }
    }
}
