using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

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

        public Genre Get(string Genre)
        {
            return _context.Genres.Include(g => g.BookGenres).ThenInclude(bg => bg.Book)
                                  .First(g => g.GName == Genre).ToDALDetails();
        }

        public string Insert(Genre entity)
        {
            try
            {
                string Genre = (_context.Genres.Add(entity.ToEF())).Entity.GName;
                _context.SaveChanges();
                return Genre;
            }
            catch (Exception)
            {
                throw new Exception("Insert failed");
            }
        }
    }
}
