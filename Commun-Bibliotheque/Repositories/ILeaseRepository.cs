using Commun_Bibliotheque.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Commun_Bibliotheque.Repositories
{
    public interface ILeaseRepository<TLease> where TLease : ILease
    {
        public IEnumerable<TLease> Get();
        public TLease Get(int id);
        public int Insert(TLease entity);
        public void Update(int id, TLease entity);
    }
}
