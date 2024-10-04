using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class AuthorService : IAuthorRepository<Author>
    {
        private IAuthorRepository<DAL.Author> _Service;
        public AuthorService(IAuthorRepository<DAL.Author> Service)
        {
            _Service = Service;
        }

        public IEnumerable<Author> Get()
        {
            return _Service.Get().Select(a => a.ToBLL());
        }

        public Author Get(int id)
        {
            return _Service.Get(id).ToBLLDetails();
        }

        public int Insert(Author entity)
        {
            return _Service.Insert(entity.ToDAL());
        }

        public void Update(int id, Author entity)
        {
            _Service.Update(id, entity.ToDAL());
        }
    }
}
