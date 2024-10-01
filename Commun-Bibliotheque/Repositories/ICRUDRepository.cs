using Commun_Bibliotheque.Entities;
using System.Collections.Generic;

namespace Commun_Bibliotheque.Repositories
{
    public interface ICRUDRepository<TEntity, TId> where TEntity : IEntity
    {
        public IEnumerable<TEntity> Get();
        public TEntity Get(TId id);
        public bool Insert(TEntity entity);
        public void Update(TId id, TEntity entity);
        public void Delete(TId id);
    }

}
