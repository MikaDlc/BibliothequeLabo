using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class SaleService : ISaleRepository<Sale>
    {
        private ISaleRepository<DAL.Sale> _saleRepository;
        public SaleService(ISaleRepository<DAL.Sale> saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public IEnumerable<Sale> Get()
        {
            return _saleRepository.Get().Select(s => s.ToBLL());
        }

        public Sale Get(int id)
        {
            return _saleRepository.Get(id).ToBLL();
        }

        public bool Insert(Sale entity)
        {
            return _saleRepository.Insert(entity.ToDAL());
        }
    }
}
