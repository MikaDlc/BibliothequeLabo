using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface ILeaseRepository<TLease> : ICRUDRepository<TLease, int> where TLease : ILease
    {
    }
}
