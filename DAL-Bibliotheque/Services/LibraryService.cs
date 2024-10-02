using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class LibraryService : ILibraryRepository<Library>
    {
        private DataContext _context;
        public LibraryService(DataContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            _context.Libraries.Remove(_context.Libraries.First(l => l.LibraryID == id));
            _context.SaveChanges();
        }

        public IEnumerable<Library> Get()
        {
            return _context.Libraries.Select(l => l.ToDAL());
        }

        public Library Get(int id)
        {
            return _context.Libraries.First(l => l.LibraryID == id).ToDAL();
        }

        public bool Insert(Library entity)
        {
            try
            {
                _context.Libraries.Add(entity.ToEF());
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(int id, Library entity)
        {
            try
            {
                var library = _context.Libraries.Find(id);
                library.Street = entity.Street;
                library.NumberH = entity.NumberH;
                library.PostalCode = entity.PostalCode;
                library.City = entity.City;
                library.Country = entity.Country;
            }
            catch (Exception)
            {
                throw new Exception("Update failed");
            }
        }
    }
}
