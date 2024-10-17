using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class ClientPost
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirsName { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [MaxLength(10)]
        public string NumberH { get; set; }
    }
}
