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
                return _context.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                                     .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre)
                                     .Include(b => b.BookLibraries).ThenInclude(bl => bl.Library)
                                     .Include(b => b.BookLeases).ThenInclude(bl => bl.Lease)
                                     .Include(b => b.BookSales).ThenInclude(bs => bs.Sale)
                                     .First(b => b.BookID == id).ToDALDetails();
            }
            catch (Exception)
            {
                return new Book();
            }
        }

        public int Insert(Book entity)
        {
            try
            {
                var book = entity.ToEF();
                _context.Books.Add(book);
                _context.SaveChanges();
                return book.BookID;
            }
            catch (Exception)
            {
                throw new Exception("Insert failed");
            }
        }

        public void Update(int id, Book entity)
        {
            try
            {
                var book = _context.Books.First(a => a.BookID == id);
                book.Title = entity.Title;
                book.Edition = entity.Edition;
                book.EditionDate = entity.EditionDate;
                book.Price = entity.Price;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update failed");
            }
        }
    }
}
