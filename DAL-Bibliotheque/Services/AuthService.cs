using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class AuthService : IAuthRepository<Auth>
    {
        private DataContext _context;
        public AuthService(DataContext context)
        {
            _context = context;
        }
        public Auth GetAuth(string email)
        {
            throw new NotImplementedException();
        }

        public string GetPassword(string email)
        {
            return _context.Clients.First(c => c.Email == email).Passwd;
        }

        public Auth Login(string email, string password)
        {
            return _context.Clients.First(c => c.Email == email && c.Passwd == password).ToDALAuth();
        }

        public bool Register(string email, string password, string name, string firstName)
        {
            Client client = new Client { Email = email, Passwd = password, Name = name, FirstName = firstName };
            try
            {
                _context.Clients.Add(client.ToEF());
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
