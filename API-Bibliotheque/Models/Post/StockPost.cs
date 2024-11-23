using System.ComponentModel.DataAnnotations;

namespace API_Bibliotheque.Models.Post
{
    public class StockPost
    {
        [Required]
        public int idBook { get; set; }
        [Required]
        public int idLibrary { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
