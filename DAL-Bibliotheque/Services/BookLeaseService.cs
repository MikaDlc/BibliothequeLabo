using Commun_Bibliotheque.Entities;
using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

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
            _context.BookLeases.Remove(_context.BookLeases.First(bl => bl.BookID == BookID && bl.LeaseID == LeaseID));
            _context.SaveChanges();
        }

        public void Insert(BookLease entity)
        {
            _context.BookLeases.Add(entity.ToEF());
            _context.SaveChanges();
        }
    }
}
