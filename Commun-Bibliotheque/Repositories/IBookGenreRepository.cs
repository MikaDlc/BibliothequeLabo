using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookGenreRepository<TBookGenre> where TBookGenre : IBookGenre
    {
        public void Insert(TBookGenre entity);
    }
}
