using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class AuthorService : IAuthorRepository<Author>
    {
        private DataContext _context;

        public AuthorService(DataContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            _context.Authors.Remove(_context.Authors.First(a => a.AuthorID == id));
            _context.SaveChanges();
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
                return _context.Authors.First(a => a.AuthorID == id).ToDAL();
            }
            catch (Exception)
            {
                return new Author();
            }
        }

        public bool Insert(Author entity)
        {
            try
            {
                _context.Authors.Add(entity.ToEF());
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(int id, Author entity)
        {
            var author = _context.Authors.First(a => a.AuthorID == id);
            author.Name = entity.Name;
            author.FirstName = entity.FirstName;
            _context.SaveChanges();
        }
    }
}
