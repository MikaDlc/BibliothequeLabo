using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class LeaseService : ILeaseRepository<Lease>
    {
        private ILeaseRepository<DAL.Lease> _leaseService;
        private IBookLibraryRepository<DAL.BookLibrary> _bookLibraryService;
        private IBookRepository<DAL.Book> _bookService;
        public LeaseService(ILeaseRepository<DAL.Lease> Service,
                            IBookLibraryRepository<DAL.BookLibrary> bookLibraryService,
                            IBookRepository<DAL.Book> bookService)
        {
            _leaseService = Service;
            _bookLibraryService = bookLibraryService;
            _bookService = bookService;
        }

        public void Delete(int id)
        {
            _leaseService.Delete(id);
        }

        public IEnumerable<Lease> Get()
        {
            return _leaseService.Get().Select(l => l.ToBLL());
        }

        public Lease Get(int id)
        {
            return _leaseService.Get(id).ToBLLDetails();
        }

        public int Insert(Lease entity)
        {
            int LeaseID = 0;
            int SucessInsert = 0;
            try
            {
                entity.LeaseDate = DateTime.Now;
                var newLease = entity.ToDALDetails();
                LeaseID = _leaseService.Insert(newLease);
                foreach (Book book in entity.Books)
                {
                    _bookLibraryService.LeaseTheBook(book.BookID, entity.LibraryID);
                    SucessInsert++;
                }
                return LeaseID;
            }
            catch (Exception ex)
            {
                Delete(LeaseID);
                foreach (Book book in entity.Books)
                {
                    if (SucessInsert > 0)
                    {
                        _bookLibraryService.ReturnTheBook(book.BookID, entity.LibraryID);
                        SucessInsert--;
                    }
                }
                throw new Exception(ex.Message);
            }
        }

        public void Update(int libraryId, Lease entity)
        {
            _leaseService.Update(entity.LeaseID, entity.ToDAL());
            Lease lease = _leaseService.Get(entity.LeaseID).ToBLLDetails();
            foreach (Book bookLease in lease.Books)
            {
                _bookLibraryService.ReturnTheBook(bookLease.BookID, libraryId);
            }
        }
    }
}
