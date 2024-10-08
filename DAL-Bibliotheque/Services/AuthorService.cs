using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class AuthorService : IAuthorRepository<Author>
    {
        private DataContext _context;

        public AuthorService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> Get()
        {
            try
            {
                return _context.Authors.Select(a => a.ToDAL());
            }
            catch (Exception)
            {
                return new List<Author>();
            }
        }

        public Author Get(int id)
        {
            try
            {
                return _context.Authors.Include(a => a.BookAuthors).ThenInclude(ba => ba.Book)
                                       .First(a => a.AuthorID == id).ToDALDetails();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid ID");
            }
        }

        public int Insert(Author entity)
        {
            try
            {
                var author = entity.ToEF();
                _context.Authors.Add(author);
                _context.SaveChanges();
                return author.AuthorID;
            }
            catch (Exception)
            {
                throw new Exception("Insert failed");
            }
        }

        public void Update(int id, Author entity)
        {
            try
            {
                var author = _context.Authors.First(a => a.AuthorID == id);
                author.Name = entity.Name;
                author.FirstName = entity.FirstName;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update failed");
            }
        }
    }
}
