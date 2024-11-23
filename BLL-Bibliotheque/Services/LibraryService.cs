using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class LibraryService : ILibraryRepository<Library>
    {
        private ILibraryRepository<DAL.Library> _libraryRepository;
        private IBookLibraryRepository<DAL.BookLibrary> _bookLibraryRepository; 
        public LibraryService(ILibraryRepository<DAL.Library> libraryRepository,
                              IBookLibraryRepository<DAL.BookLibrary> bookLibraryRepository)
        {
            _libraryRepository = libraryRepository;
            _bookLibraryRepository = bookLibraryRepository;
        }

        public IEnumerable<Library> Get()
        {
            return _libraryRepository.Get().Select(l => l.ToBLL());
        }

        public Library Get(int id)
        {
            return _libraryRepository.Get(id).ToBLLDetails();
        }

        public int Insert(Library entity)
        {
            return _libraryRepository.Insert(entity.ToDAL());
        }

        public void Update(int idBook, int idLibrary, int Stock)
        {
            _bookLibraryRepository.Update(idBook, idLibrary, Stock);
        }
    }
}
