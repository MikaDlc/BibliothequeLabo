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

        public string GetPassword(string email)
        {
            try
            {
                var client = _context.Clients.First(c => c.Email == email);
                if (client is not null)
                    return client.Passwd;
                else
                    throw new Exception("Client not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Auth Login(string email, string password)
        {
            return _context.Clients.First(c => c.Email == email && c.Passwd == password).ToDALAuth();
        }

        public bool Register(string email, string password, string name, string firstName, bool isAdmin)
        {
            Client client = new Client { Email = email, Passwd = password, Name = name, FirstName = firstName, IsAdmin = isAdmin };
            try
            {
                _context.Clients.Add(client.ToEFAuth());
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
