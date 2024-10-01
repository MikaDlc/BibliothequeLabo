using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface ILibraryRepository<TLibrary> : ICRUDRepository<TLibrary, int> where TLibrary : ILibrary
    {
    }
}
