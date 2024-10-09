using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class BookLeaseService : IBookLeaseRepository<BookLease>
    {
        private DataContext _context;
        public BookLeaseService(DataContext context)
        {
            _context = context;
        }

        public void Delete(int BookID, int LeaseID)
        {
            var bookLease = _context.BookLeases.Find(BookID, LeaseID);
            if (bookLease != null)
            {
                _context.BookLeases.Remove(bookLease);
                _context.SaveChanges();
            }
        }

        public void Insert(BookLease entity)
        {
            try
            {
                _context.BookLeases.Add(entity.ToEF());
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Invalid Book");
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid Book");
            }
        }
    }
}
