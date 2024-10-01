using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class ClientService : IClientRepository<Client>
    {
        private DataContext _context;
        public ClientService(DataContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            _context.Clients.Remove(_context.Clients.First(a => a.ClientID == id));
            _context.SaveChanges();
        }

        public IEnumerable<Client> Get()
        {
            try
            {
                return _context.Clients.Select(a => a.ToDAL());
            }
            catch (Exception)
            {
                return new List<Client>();
            }
        }

        public Client Get(int id)
        {
            try
            {
                return _context.Clients.First(a => a.ClientID == id).ToDAL();
            }
            catch (Exception)
            {
                return new Client();
            }
        }

        public bool Insert(Client entity)
        {
            try
            {
                _context.Clients.Add(entity.ToEF());
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(int id, Client entity)
        {
            try
            {
                var client = _context.Clients.First(a => a.ClientID == id);
                client.Name = entity.Name;
                client.FirstName = entity.FirstName;
                client.Street = entity.Street;
                client.NumberH = entity.NumberH;
                client.PostalCode = entity.PostalCode;
                client.City = entity.City;
                client.Country = entity.Country;
                client.Email = entity.Email;
                client.Passwd = entity.Passwd;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update failed");
            }
        }
    }
}
