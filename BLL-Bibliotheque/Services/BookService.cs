using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class BookService : IBookRepository<Book>
    {
        private IBookRepository<DAL.Book> _bookService;
        private IBookLibraryRepository<DAL.BookLibrary> _bookLibraryService;
        private IAuthorRepository<DAL.Author> _authorService;
        private IGenreRepository<DAL.Genre> _genreService;

        public BookService(IBookRepository<DAL.Book> Service,
                           IBookLibraryRepository<DAL.BookLibrary> bookLibraryService,
                           IAuthorRepository<DAL.Author> authorService,
                           IGenreRepository<DAL.Genre> genreService)
        {
            _bookService = Service;
            _bookLibraryService = bookLibraryService;
            _authorService = authorService;
            _genreService = genreService;
        }

        public void Delete(int id)
        {
            _bookService.Delete(id);
        }

        public IEnumerable<Book> Get()
        {
            return _bookService.Get().Select(b => b.ToBLL());
        }

        public Book Get(int id)
        {
            return _bookService.Get(id).ToBLLDetails();
        }

        public int Insert(Book entity)
        {
            // TODO: Implementer la Transaction
            int BookID = 0;
            try
            {
                var newBook = entity.ToDALDetails();
                BookID = _bookService.Insert(newBook);
                foreach (LibraryStock bookLibrary in entity.Libraries)
                    _bookLibraryService.Insert(new DAL.BookLibrary { BookID = BookID, LibraryID = bookLibrary.LibraryID, QDispo = bookLibrary.Stock });
                return BookID;
            }
            catch (Exception ex)
            {
                Delete(BookID); // Rollback
                foreach (LibraryStock bookLibrary in entity.Libraries)
                    _bookLibraryService.Delete(BookID, bookLibrary.LibraryID); // Rollback
                throw new Exception(ex.Message);
            }
        }
    }
}
