using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace DAL_Bibliotheque.Entities
{
    public class Author : IAuthor
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public List<Book> Books { get; set; }
    }
}
