using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class BookLibraryService : IBookLibraryRepository<BookLibrary>
    {
        private DataContext _context;
        public BookLibraryService(DataContext context)
        {
            _context = context;
        }

        public void Insert(BookLibrary entity)
        {
            try
            {
                _context.BookLibraries.Add(entity.ToEF());
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Invalid Library");
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid Library");
            }
        }

        public void LeaseTheBook(int BookID, int LibraryID)
        {
            var bookLibrary = _context.BookLibraries.First(bl => bl.LibraryID == LibraryID && bl.BookID == BookID);
            bookLibrary.QDispo = --bookLibrary.QDispo;
            _context.SaveChanges();
        }

        public void ReturnTheBook(int BookID, int LibraryID)
        {
            var bookLibrary = _context.BookLibraries.First(bl => bl.LibraryID == LibraryID && bl.BookID == BookID);
            bookLibrary.QDispo = ++bookLibrary.QDispo;
            _context.SaveChanges();
        }
    }
}
