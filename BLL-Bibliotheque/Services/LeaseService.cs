using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class LeaseService : ILeaseRepository<Lease>
    {
        private ILeaseRepository<DAL.Lease> _leaseService;
        private IBookLeaseRepository<DAL.BookLease> _bookLeaseService;
        private IBookLibraryRepository<DAL.BookLibrary> _bookLibraryService;
        private IBookRepository<DAL.Book> _bookService;
        public LeaseService(ILeaseRepository<DAL.Lease> Service, 
                            IBookLeaseRepository<DAL.BookLease> bookLeaseService, 
                            IBookLibraryRepository<DAL.BookLibrary> bookLibraryService,
                            IBookRepository<DAL.Book> bookService)
        {
            _leaseService = Service;
            _bookLeaseService = bookLeaseService;
            _bookLibraryService = bookLibraryService;
            _bookService = bookService;
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
            entity.LeaseDate = DateTime.Now;
            int LeaseID = _leaseService.Insert(entity.ToDAL());
            foreach (Book bookLease in entity.Books)
            {
                _bookLeaseService.Insert(
                    new DAL.BookLease
                    {
                        LeaseID = LeaseID,
                        BookID = bookLease.BookID
                    }
                );

                int LibraryID = _bookService.Get(bookLease.BookID).BookLibraries[0].LibraryID;
                _bookLibraryService.LeaseTheBook(bookLease.BookID,LibraryID);
            }

            return LeaseID;
        }

        public void Update(int id, Lease entity)
        {
            _leaseService.Update(id, entity.ToDAL());
            Lease lease = _leaseService.Get(id).ToBLLDetails();
            foreach (Book bookLease in lease.Books)
            {
                int LibraryID = _bookService.Get(bookLease.BookID).BookLibraries[0].LibraryID;
                _bookLibraryService.ReturnTheBook(bookLease.BookID, LibraryID);
            }
        }
    }
}
