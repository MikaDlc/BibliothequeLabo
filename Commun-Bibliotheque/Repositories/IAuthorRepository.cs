using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IAuthorRepository<TAutor> : ICRUDRepository<TAutor, int> where TAutor : IAuthor
    {
    }
}
