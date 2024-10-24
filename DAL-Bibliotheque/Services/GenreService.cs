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
            try
            {
                return _context.Genres.Include(g => g.Books)
                                      .First(g => g.GName == Genre).ToDALDetails();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid ID");
            }
        }

        public string Insert(Genre entity)
        {
            try
            {
                var genre = entity.ToEF();
                _context.Genres.Add(genre);
                _context.SaveChanges();
                return genre.GName;
            }
            catch (Exception)
            {
                throw new Exception("Insert failed");
            }
        }
    }
}
