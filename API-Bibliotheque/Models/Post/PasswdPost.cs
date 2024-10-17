using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class PasswdPost
    {
        [Required]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
    }
}
