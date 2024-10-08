using API_Bibliotheque.Models.Get;

namespace API_Bibliotheque.Models.GetDetails
{
    public class AuthorDetails
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public List<BookGet> Books { get; set; }
    }
}
