using System;
using System.Collections.Generic;

namespace DomainModel.Infrastracture.Daos
{
    public interface IDao<T> : IInDaos<T>, IOutDaos<T>
    {
        new IEnumerable<T> All();
        new T Find(long id);
        new void Add(T value);
        new void Update(long id, T value);
        void Delete(long id);
    }
}
