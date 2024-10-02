using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace Commun_Bibliotheque.Repositories
{
    public interface IGenreRepository<TGenre> where TGenre : IGenre
    {
        public IEnumerable<TGenre> Get();
        public TGenre Get(string id);
        public bool Insert(TGenre entity);

    }
}
