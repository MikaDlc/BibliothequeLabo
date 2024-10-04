using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class BookSaleService : IBookSaleRepository<BookSale>
    {
        private DataContext _context;
        public BookSaleService(DataContext context)
        {
            _context = context;
        }
        public void Delete(int BookID, int SaleID)
        {
            _context.BookSales.Remove(_context.BookSales.First(bs => bs.BookID == BookID && bs.SaleID == SaleID));
            _context.SaveChanges();
        }

        public void Insert(BookSale entity)
        {
            _context.BookSales.Add(entity.ToEF());
            _context.SaveChanges();
        }
    }
}
