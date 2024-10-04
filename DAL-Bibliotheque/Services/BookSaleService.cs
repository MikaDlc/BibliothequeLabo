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

        public void Insert(BookSale entity)
        {
            _context.BookSales.Add(entity.ToEF());
            _context.SaveChanges();
        }

        public void SaleTheBook(int BookID, int LibraryID)
        {
            var bookLibrary = _context.BookLibraries.First(bl => bl.LibraryID == LibraryID && bl.BookID == BookID);
            bookLibrary.QDispo = --bookLibrary.QDispo;
            _context.SaveChanges();
        }
    }
}
