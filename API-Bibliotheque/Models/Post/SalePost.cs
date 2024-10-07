using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class SalePost
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        [Length(1, 100)]
        public List<int> Books { get; set; }
    }
}
