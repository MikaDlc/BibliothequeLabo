using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class EmailPost
    {

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
