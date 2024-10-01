using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IGenreRepository<TGenre> : ICRUDRepository<TGenre, int> where TGenre : IGenre
    {
    }
}
