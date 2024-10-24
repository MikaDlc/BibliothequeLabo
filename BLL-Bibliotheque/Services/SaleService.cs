using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class SaleService : ISaleRepository<Sale>
    {
        private ISaleRepository<DAL.Sale> _saleRepository;
        private IBookLibraryRepository<DAL.BookLibrary> _bookLibraryService;
        private IBookRepository<DAL.Book> _bookService;
        public SaleService(ISaleRepository<DAL.Sale> saleRepository,
                           IBookLibraryRepository<DAL.BookLibrary> bookLibraryRepository,
                           IBookRepository<DAL.Book> bookRepository)
        {
            _saleRepository = saleRepository;
            _bookLibraryService = bookLibraryRepository;
            _bookService = bookRepository;
        }

        public void Delete(int id)
        {
            _saleRepository.Delete(id);
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
            int saleID = 0;
            int SucessInsert = 0;
            try
            {
                entity.DateSale = DateTime.Now;
                var newSale = entity.ToDAL();
                saleID = _saleRepository.Insert(newSale);
                foreach (Book book in entity.Books)
                {
                    _bookLibraryService.LeaseTheBook(book.BookID, entity.LibraryID);
                    SucessInsert++;
                }

                return saleID;
            }
            catch (Exception ex)
            {
                Delete(saleID);
                foreach (Book book in entity.Books)
                {
                        _bookLibraryService.ReturnTheBook(book.BookID, entity.LibraryID);
                }
                throw new Exception(ex.Message);
            }
        }
    }
}
