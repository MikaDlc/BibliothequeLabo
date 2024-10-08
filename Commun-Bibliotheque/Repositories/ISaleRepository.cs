using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace Commun_Bibliotheque.Repositories
{
    public interface ISaleRepository<TSale> where TSale : ISale
    {
        public IEnumerable<TSale> Get();
        public TSale Get(int id);
        public int Insert(TSale entity);
        public void Delete(int id);
    }
}
