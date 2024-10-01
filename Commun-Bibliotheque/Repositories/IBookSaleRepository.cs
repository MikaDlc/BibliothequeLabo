using Commun_Bibliotheque.Entities;

namespace Commun_Bibliotheque.Repositories
{
    public  interface IBookSaleRepository<TBookSale> : ICRUDRepository<TBookSale, int> where TBookSale : IBookSale
    {
    }
}
