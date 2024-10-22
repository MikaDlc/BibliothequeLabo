using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Auth
{
    public class RegisterPostAdmin
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
        [Required]
        public bool IsAdmin { get; set; }
    }
}
