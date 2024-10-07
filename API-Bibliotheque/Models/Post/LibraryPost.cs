using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class LibraryPost
    {
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        public string NumberH { get; set; }
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Country { get; set; } = "Belgique";
    }
}
