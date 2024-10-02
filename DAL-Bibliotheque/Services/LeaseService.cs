using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class LeaseService : ILeaseRepository<Lease>
    {
        private DataContext _context;
        public LeaseService(DataContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            _context.Leases.Remove(_context.Leases.First(l => l.LeaseID == id));
            _context.SaveChanges();
        }

        public IEnumerable<Lease> Get()
        {
            return _context.Leases.Select(l => l.ToDAL());
        }

        public Lease Get(int id)
        {
            return _context.Leases.First(l => l.LeaseID == id).ToDAL();
        }

        public bool Insert(Lease entity)
        {
            // TODO Gerer l'ClientID non présent
            try
            {
                _context.Leases.Add(entity.ToEF());
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(int id, Lease entity)
        {
            try
            {
                var lease = _context.Leases.First(l => l.LeaseID == id);
                lease.ReturnDate = entity.ReturnDate;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update failed");
            }
        }
    }
}
