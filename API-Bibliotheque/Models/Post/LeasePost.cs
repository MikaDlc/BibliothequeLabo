namespace API_Bibliotheque.Models.Post
{
    public class LeasePost
    {
        public DateTime LeaseDate { get; set; }
        public int ClientID { get; set; }
        public double Price { get; set; }
        public List<int> Books { get; set; }
    }
}
