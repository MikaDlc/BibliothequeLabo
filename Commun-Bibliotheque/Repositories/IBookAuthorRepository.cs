using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookAuthorRepository<TBookAuthor> : ICRUDRepository<TBookAuthor, int> where TBookAuthor : IBookAuthor
    {
    }
}
