using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookRepository<Tbook> where Tbook : IBook
    {
        public IEnumerable<Tbook> Get();
        public Tbook Get(int id);
        public int Insert(Tbook entity);
        public void Update(int id, Tbook entity);
    }
}
