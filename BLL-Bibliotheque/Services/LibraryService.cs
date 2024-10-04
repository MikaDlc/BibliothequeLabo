using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class LibraryService : ILibraryRepository<Library>
    {
        private ILibraryRepository<DAL.Library> _libraryRepository;
        public LibraryService(ILibraryRepository<DAL.Library> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        public void Delete(int id)
        {
            _libraryRepository.Delete(id);
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

        public void Update(int id, Library entity)
        {
            _libraryRepository.Update(id, entity.ToDAL());
        }
    }
}
