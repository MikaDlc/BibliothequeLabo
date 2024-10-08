using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;
using Microsoft.EntityFrameworkCore;

namespace DAL_Bibliotheque.Services
{
    public class BookGenreService : IBookGenreRepository<BookGenre>
    {
        private DataContext _context;
        public BookGenreService(DataContext context)
        {
            _context = context;
        }

        public void Insert(BookGenre entity)
        {
            try
            {
                _context.BookGenres.Add(entity.ToEF());
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Invalid Genre");
            }
        }
    }
}
