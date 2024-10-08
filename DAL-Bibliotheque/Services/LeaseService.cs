using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

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
            var lease = _context.Leases.Find(id);
            if (lease != null)
            {
                _context.Leases.Remove(lease);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Lease> Get()
        {
            return _context.Leases.Select(l => l.ToDAL());
        }

        public Lease Get(int id)
        {
            try
            {
                return _context.Leases.Include(l => l.BookLeases).ThenInclude(bl => bl.Book)
                                      .Include(l => l.Client)
                                      .First(l => l.LeaseID == id).ToDALDetails();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid ID");
            }
        }

        public int Insert(Lease entity)
        {
            try
            {
                var lease = entity.ToEF();
                _context.Leases.Add(lease);
                _context.SaveChanges();
                return lease.LeaseID;
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Invalid Client");
            }
        }

        public void Update(int id, Lease entity)
        {
            try
            {
                if (_context.Leases.First(l => l.LeaseID == id).ReturnDate is null)
                {
                    var lease = _context.Leases.First(l => l.LeaseID == id);
                    lease.ReturnDate = entity.ReturnDate;
                    _context.SaveChanges();
                }
                else
                {
                    throw new DbUpdateException();
                }
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Lease already returned");
            }
            catch (Exception)
            {
                throw new Exception("Update failed");
            }
        }
    }
}
