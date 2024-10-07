using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class GenrePost
    {
        [Required]
        [MaxLength(50)]
        public string GName { get; set; }
    }
}
