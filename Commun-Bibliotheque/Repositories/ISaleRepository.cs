using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface ISaleRepository<TSale> : ICRUDRepository<TSale, int> where TSale : ISale
    {
    }
}
