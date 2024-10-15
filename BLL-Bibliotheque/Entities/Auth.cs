using Commun_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Entities
{
    public class Auth : IAuth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
