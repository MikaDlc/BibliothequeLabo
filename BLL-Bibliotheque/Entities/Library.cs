﻿using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace BLL_Bibliotheque.Entities
{
    public class Library : ILibrary
    {
        public int LibraryID { get; set; }
        public string Street { get; set; }
        public string NumberH { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Book> Books { get; set; }
    }
}
