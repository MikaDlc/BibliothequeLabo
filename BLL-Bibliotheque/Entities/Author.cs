using Commun_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Entities
{
    public class Author : IAuthor
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
