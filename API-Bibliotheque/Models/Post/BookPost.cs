using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class BookPost
    {
        [Required]
        [MaxLength(450)]
        public string Title { get; set; }
        [Required]
        [MaxLength(450)]
        public string Edition { get; set; }
        [Required]
        [Range(1970, 2100)]
        public int EditionDate { get; set; }
        [Required]
        public double Price { get; set; }
        public List<int> Libraries { get; set; }
        public List<int> LibraryQuantity { get; set; }
        public List<int> Authors { get; set; }
        public List<string> Genres { get; set; }

    }
}
