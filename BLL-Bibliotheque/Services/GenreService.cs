using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class GenreService : IGenreRepository<Genre>
    {
        private IGenreRepository<DAL.Genre> _Service;
        public GenreService(IGenreRepository<DAL.Genre> Service)
        {
            _Service = Service;
        }
        public IEnumerable<Genre> Get()
        {
            return _Service.Get().Select(c => c.ToBLL());
        }

        public Genre Get(string id)
        {
            return _Service.Get(id).ToBLLDetails();
        }

        public bool Insert(Genre entity)
        {
            return _Service.Insert(entity.ToDAL());
        }
    }
}
