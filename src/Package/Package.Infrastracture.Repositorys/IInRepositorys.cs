using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Infrastracture.Repositorys
{
    public interface IInRepositorys<in TEntity>
    {
        void Add(TEntity value);
        void Update(long id, TEntity value);
    }
}
