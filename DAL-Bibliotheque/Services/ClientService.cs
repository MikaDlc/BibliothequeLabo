using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class ClientService : IClientRepository<Client>
    {
        private DataContext _context;
        public ClientService(DataContext context)
        {
            _context = context;
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
                return _context.Clients.Include(c => c.Leases).ThenInclude(bl => bl.Book)
                                       .Include(c => c.Sales).ThenInclude(bs => bs.Book)
                                       .First(a => a.ClientID == id).ToDALDetails();
            }
            catch (Exception)
            {
                return new Client();
            }
        }

        public int Insert(Client entity)
        {
            try
            {
                var client = entity.ToEF();
                _context.Clients.Add(client);
                _context.SaveChanges();
                return client.ClientID;
            }
            catch (Exception)
            {
                throw new Exception("Insert failed");
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
