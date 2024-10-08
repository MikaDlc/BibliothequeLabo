using API_Bibliotheque.Models.Get;

namespace API_Bibliotheque.Models.GetDetails
{
    public class GenreDetails
    {
        public string GName { get; set; }
        public List<BookGet> Books { get; set; }
    }
}
