using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookLeaseRepository<TBookLease> : ICRUDRepository<TBookLease, int> where TBookLease : IBookLease
    {
    }
}
