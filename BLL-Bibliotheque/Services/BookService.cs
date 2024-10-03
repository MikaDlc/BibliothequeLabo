using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class BookService : IBookRepository<Book>
    {
        private IBookRepository<DAL.Book> _Service;

        public BookService(IBookRepository<DAL.Book> Service)
        {
            _Service = Service;
        }
        public void Delete(int id)
        {
            _Service.Delete(id);
        }

        public IEnumerable<Book> Get()
        {
            return _Service.Get().Select(b => b.ToBLL());
        }

        public Book Get(int id)
        {
            return _Service.Get(id).ToBLLDetails();
        }

        public bool Insert(Book entity)
        {
            return _Service.Insert(entity.ToDAL());
        }

        public void Update(int id, Book entity)
        {
            _Service.Update(id, entity.ToDAL());
        }
    }
}
