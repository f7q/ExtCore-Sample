using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Infrastracture.Repositorys
{
    public interface IOutRepositorys<out TEntity>
    {
        IEnumerable<TEntity> All();
        TEntity Find(long id);
    }
}
