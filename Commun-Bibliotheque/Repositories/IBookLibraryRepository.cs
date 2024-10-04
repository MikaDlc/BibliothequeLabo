using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookLibraryRepository<TBookLibrary> where TBookLibrary : IBookLibrary
    {
        public void Insert(TBookLibrary entity);
        public void Delete(int BookID, int LibraryID);
    }
}
