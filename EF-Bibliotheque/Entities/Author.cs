namespace EF_Bibliotheque.Entities
{
    internal class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
