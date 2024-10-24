﻿namespace EF_Bibliotheque.Entities
{
    public class Sale
    {
        public int SaleID { get; set; }
        public double Price { get; set; }
        public DateTime DateSale { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
