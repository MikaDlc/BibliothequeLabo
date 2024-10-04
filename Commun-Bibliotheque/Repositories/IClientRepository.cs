using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace Commun_Bibliotheque.Repositories
{
    public interface IClientRepository<TClient> where TClient : IClient
    {
        public IEnumerable<TClient> Get();
        public TClient Get(int id);
        public int Insert(TClient entity);
        public void Update(int id, TClient entity);
    }
}
