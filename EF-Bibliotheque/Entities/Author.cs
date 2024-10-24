﻿namespace EF_Bibliotheque.Entities
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}