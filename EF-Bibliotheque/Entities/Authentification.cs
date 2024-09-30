namespace EF_Bibliotheque.Entities
{
    internal class Authentification
    {
        public int AuthentificationID { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public string Salage { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}
