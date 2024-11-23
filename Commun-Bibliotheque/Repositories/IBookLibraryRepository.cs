using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookLibraryRepository<TBookLibrary> where TBookLibrary : IBookLibrary
    {
        public void Insert(TBookLibrary entity);
        public void Delete(int BookID, int LibraryID);
        public void LeaseTheBook(int BookID, int LibraryID);
        public void ReturnTheBook(int BookID, int LibraryID);
        public void Update(int idBook, int idLibrary, int Stock);
    }
}
