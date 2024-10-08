using Commun_Bibliotheque.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Commun_Bibliotheque.Repositories
{
    public interface IAuthorRepository<TAutor> where TAutor : IAuthor
    {

        public IEnumerable<TAutor> Get();
        public TAutor Get(int id);
        public int Insert(TAutor entity);
    }
}
