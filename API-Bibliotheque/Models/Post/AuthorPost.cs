using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class AuthorPost
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required] 
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
