using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public interface IClientRepository<TClient> : ICRUDRepository<TClient, int> where TClient : IClient
    {
    }
}
