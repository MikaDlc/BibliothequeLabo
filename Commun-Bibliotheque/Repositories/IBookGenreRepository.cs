using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookGenreRepository<TBookGenre> : ICRUDRepository<TBookGenre, int> where TBookGenre : IBookGenre
    {
    }
}
