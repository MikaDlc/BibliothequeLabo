using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookAuthorRepository<TBookAuthor> where TBookAuthor : IBookAuthor
    {
        public void Insert(TBookAuthor entity);
        public void Delete(int BookID, int AuthorID);
    }
}
