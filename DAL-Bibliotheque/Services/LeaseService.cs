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
            // TODO Gerer l'ClientID non présent
            try
            {
                var lease = entity.ToEF();
                _context.Leases.Add(lease);
                _context.SaveChanges();
                return lease.LeaseID;
            }
            catch (Exception)
            {
                throw new Exception("Insert failed");
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
