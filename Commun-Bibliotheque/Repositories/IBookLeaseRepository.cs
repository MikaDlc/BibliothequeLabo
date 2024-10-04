using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IBookLeaseRepository<TBookLease> where TBookLease : IBookLease
    {
        public void Insert(TBookLease entity);
    }
}
