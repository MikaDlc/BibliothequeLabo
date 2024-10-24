using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class BookService : IBookRepository<Book>
    {
        private DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Book> Get()
        {
            try
            {
                return _context.Books.Select(a => a.ToDAL());
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public Book Get(int id)
        {
            try
            {
                return _context.Books.Include(b => b.Genres)
                                     .Include(b => b.Authors)
                                     .Include(b => b.BookLibraries).ThenInclude(bl => bl.Library)
                                     .First(b => b.BookID == id).ToDALDetails();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid ID");
            }
        }

        public int Insert(Book entity)
        {
            try
            {
                var book = entity.ToEF();
                book.Authors = entity.Authors.Select(a => _context.Authors.Find(a.AuthorID)).ToList();
                book.Genres = entity.Genres.Select(g => _context.Genres.Find(g.GName)).ToList();
                _context.Books.Add(book);
                _context.SaveChanges();
                return book.BookID;
            }
            catch (Exception)
            {
                throw new Exception("Insert failed");
            }
        }
    }
}
