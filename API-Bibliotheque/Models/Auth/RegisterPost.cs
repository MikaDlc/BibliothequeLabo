using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Auth
{
    public class RegisterPost
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirsName { get; set; }
    }
}
