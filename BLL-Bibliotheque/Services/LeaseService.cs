using BLL_Bibliotheque.Entities;
using BLL_Bibliotheque.Mapper;
using Commun_Bibliotheque.Repositories;
using DAL = DAL_Bibliotheque.Entities;

namespace BLL_Bibliotheque.Services
{
    public class LeaseService : ILeaseRepository<Lease>
    {
        private ILeaseRepository<DAL.Lease> _Service;
        public LeaseService(ILeaseRepository<DAL.Lease> Service)
        {
            _Service = Service;
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
            return _Service.Get(id).ToBLL();
        }

        public bool Insert(Lease entity)
        {
            return _Service.Insert(entity.ToDAL());
        }

        public void Update(int id, Lease entity)
        {
            _Service.Update(id, entity.ToDAL());
        }
    }
}
