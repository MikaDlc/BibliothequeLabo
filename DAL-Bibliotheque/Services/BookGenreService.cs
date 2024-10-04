using Commun_Bibliotheque.Repositories;
using DAL_Bibliotheque.Entities;
using DAL_Bibliotheque.Mapper;
using EF_Bibliotheque;

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
            _context.BookGenres.Add(entity.ToEF());
            _context.SaveChanges();
        }
    }
}
