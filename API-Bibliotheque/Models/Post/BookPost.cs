using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class BookPost
    {
        public string Title { get; set; }
        public string Edition { get; set; }
        public int EditionDate { get; set; }
        public double Price { get; set; }
        public List<int> Libraries { get; set; }
        public List<int> LibraryQuantity { get; set; }
        public List<int> Authors { get; set; }
        public List<string> Genres { get; set; }

    }
}
