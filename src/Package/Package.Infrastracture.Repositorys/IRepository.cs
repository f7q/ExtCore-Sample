using System;
using System.Collections.Generic;

namespace Package.Infrastracture.Repositorys
{
    public interface IRepository<TEntity> : IInRepositorys<TEntity>, IOutRepositorys<TEntity>
    {
        new IEnumerable<TEntity> All();
        new TEntity Find(long id);
        new void Add(TEntity value);
        new void Update(long id, TEntity value);
        void Delete(long id);
    }
}
