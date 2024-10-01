using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

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
            _context.Books.Remove(_context.Books.First(a => a.BookID == id));
            _context.SaveChanges();
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
                return _context.Books.First(a => a.BookID == id).ToDAL();
            }
            catch (Exception)
            {
                return new Book();
            }
        }

        public bool Insert(Book entity)
        {
            try
            {
                _context.Books.Add(entity.ToEF());
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(int id, Book entity)
        {
            try
            {
                Book a = _context.Books.First(a => a.BookID == id).ToDAL();
                a.Title = entity.Title;
                a.Edition = entity.Edition;
                a.EditionDate = entity.EditionDate;
                a.Price = entity.Price;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update failed");
            }
        }
    }
}
