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
        private IBookLibraryRepository<DAL.BookLibrary> _bookLibraryService;
        private IBookRepository<DAL.Book> _bookService;
        public SaleService(ISaleRepository<DAL.Sale> saleRepository,
                           IBookSaleRepository<DAL.BookSale> bookSaleRepository,
                           IBookLibraryRepository<DAL.BookLibrary> bookLibraryRepository,
                           IBookRepository<DAL.Book> bookRepository)
        {
            _saleRepository = saleRepository;
            _bookSaleRepository = bookSaleRepository;
            _bookLibraryService = bookLibraryRepository;
            _bookService = bookRepository;
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
            try
            {
                entity.DateSale = DateTime.Now;
                int saleID = _saleRepository.Insert(entity.ToDAL());
                foreach (Book bookSale in entity.Books)
                {
                    _bookSaleRepository.Insert(
                        new DAL.BookSale
                        {
                            SaleID = saleID,
                            BookID = bookSale.BookID
                        }
                    );

                    int LibraryID = _bookService.Get(bookSale.BookID).BookLibraries[0].LibraryID;
                    _bookLibraryService.LeaseTheBook(bookSale.BookID, LibraryID);
                }

                return saleID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
