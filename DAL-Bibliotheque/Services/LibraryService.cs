using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class LibraryService : ILibraryRepository<Library>
    {
        private DataContext _context;
        public LibraryService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Library> Get()
        {
            return _context.Libraries.Select(l => l.ToDAL());
        }

        public Library Get(int id)
        {
            return _context.Libraries.Include(l => l.BookLibraries).ThenInclude(bl => bl.Book)
                                     .First(l => l.LibraryID == id).ToDALDetails();
        }

        public int Insert(Library entity)
        {
            try
            {
                var library = entity.ToEF();
                _context.Libraries.Add(library);
                _context.SaveChanges();
                return library.LibraryID;
            }
            catch (Exception)
            {
                throw new Exception("Insert failed");
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
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update failed");
            }
        }
    }
}
