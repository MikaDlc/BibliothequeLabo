using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

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
            var bookSale = _context.BookSales.Find(BookID, SaleID);
            if (bookSale != null)
            {
                _context.BookSales.Remove(bookSale);
                _context.SaveChanges();
            }
        }

        public void Insert(BookSale entity)
        {
            try
            {
                _context.BookSales.Add(entity.ToEF());
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

        public void SaleTheBook(int BookID, int LibraryID)
        {
            var bookLibrary = _context.BookLibraries.First(bl => bl.LibraryID == LibraryID && bl.BookID == BookID);
            bookLibrary.QDispo = --bookLibrary.QDispo;
            _context.SaveChanges();
        }
    }
}
