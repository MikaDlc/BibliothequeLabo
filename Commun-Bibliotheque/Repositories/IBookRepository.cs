using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookRepository<Tbook> : ICRUDRepository<Tbook, int> where Tbook : IBook
    {
    }
}
