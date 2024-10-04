using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class SaleService : ISaleRepository<Sale>
    {
        private ISaleRepository<DAL.Sale> _saleRepository;
        private IBookSaleRepository<DAL.BookSale> _bookSaleRepository;
        public SaleService(ISaleRepository<DAL.Sale> saleRepository, IBookSaleRepository<DAL.BookSale> bookSaleRepository)
        {
            _saleRepository = saleRepository;
            _bookSaleRepository = bookSaleRepository;
        }
        public IEnumerable<Sale> Get()
        {
            return _saleRepository.Get().Select(s => s.ToBLL());
        }

        public Sale Get(int id)
        {
            return _saleRepository.Get(id).ToBLLDetails();
        }

        public int Insert(Sale entity)
        {
            int saleID = _saleRepository.Insert(entity.ToDAL());
            foreach (var bookSale in entity.BookSales) 
                _bookSaleRepository.Insert(new DAL.BookSale { SaleID = saleID, BookID = bookSale.BookID});

            return saleID;
        }
    }
}
