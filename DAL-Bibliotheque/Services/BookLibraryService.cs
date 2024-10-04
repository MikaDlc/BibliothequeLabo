using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class BookLibraryService : IBookLibraryRepository<BookLibrary>
    {
        private DataContext _context;
        public BookLibraryService(DataContext context)
        {
            _context = context;
        }
        public void Delete(int BookID, int LibraryID)
        {
            _context.BookLibraries.Remove(_context.BookLibraries.First(bl => bl.LibraryID == LibraryID && bl.BookID == BookID));
            _context.SaveChanges();
        }

        public void Insert(BookLibrary entity)
        {
            _context.BookLibraries.Add(entity.ToEF());
            _context.SaveChanges();
        }
    }
}
