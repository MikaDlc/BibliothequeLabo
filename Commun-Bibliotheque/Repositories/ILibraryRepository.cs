using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace Commun_Bibliotheque.Repositories
{
    public interface ILibraryRepository<TLibrary> where TLibrary : ILibrary
    {
        public IEnumerable<TLibrary> Get();
        public TLibrary Get(int id);
        public int Insert(TLibrary entity);
    }
}
