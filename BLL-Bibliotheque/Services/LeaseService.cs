using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class LeaseService : ILeaseRepository<Lease>
    {
        private ILeaseRepository<DAL.Lease> _Service;
        private IBookLeaseRepository<DAL.BookLease> _bookLeaseService;
        public LeaseService(ILeaseRepository<DAL.Lease> Service, IBookLeaseRepository<DAL.BookLease> bookLeaseService)
        {
            _Service = Service;
            _bookLeaseService = bookLeaseService;
        }
        public void Delete(int id)
        {
            _Service.Delete(id);
        }

        public IEnumerable<Lease> Get()
        {
            return _Service.Get().Select(l => l.ToBLL());
        }

        public Lease Get(int id)
        {
            return _Service.Get(id).ToBLLDetails();
        }

        public int Insert(Lease entity)
        {
            int LeaseID = _Service.Insert(entity.ToDAL());
            foreach (BookLease bookLease in entity.BookLeases)
                _bookLeaseService.Insert(new DAL.BookLease { LeaseID = LeaseID, BookID = bookLease.BookID });

            return LeaseID;
        }

        public void Update(int id, Lease entity)
        {
            _Service.Update(id, entity.ToDAL());
        }
    }
}
