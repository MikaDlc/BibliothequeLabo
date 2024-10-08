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
        [Required]
        [Length(1, 100)]
        public List<int> Libraries { get; set; }
        [Required]
        [Length(1, 100)]
        public List<int> LibraryQuantity { get; set; }
        [Required]
        [Length(1, 100)]
        public List<int> Authors { get; set; }
        [Required]
        [Length(1, 100)]
        public List<string> Genres { get; set; }
    }
}
