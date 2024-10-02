using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

namespace DAL_Bibliotheque.Services
{
    public class GenreService : IGenreRepository<Genre>
    {
        private DataContext _context;
        public GenreService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> Get()
        {
            return _context.Genres.Select(g => g.ToDAL());
        }

        public bool Insert(Genre entity)
        {
            try
            {
                _context.Genres.Add(entity.ToEF());
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
