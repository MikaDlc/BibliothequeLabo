using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class BookAuthorService : IBookAuthorRepository<BookAuthor>
    {
        private DataContext _context;
        public BookAuthorService(DataContext context)
        {
            _context = context;
        }

        public void Delete(int BookID, int AuthorID)
        {
            _context.BookAuthors.Remove(_context.BookAuthors.First(ba => ba.AuthorID == AuthorID && ba.BookID == BookID));
            _context.SaveChanges();
        }

        public void Insert(BookAuthor entity)
        {
            _context.BookAuthors.Add(entity.ToEF());
            _context.SaveChanges();
        }
    }
}
