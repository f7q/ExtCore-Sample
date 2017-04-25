using System;
using System.Collections.Generic;
using DomainModel.Models;

namespace DomainModel.Infrastracture.Repositorys
{
    public interface IRepository<T> : IInRepositorys<T>, IOutRepositorys<T>
    {
        new IEnumerable<T> All();
        new T Find(long id);
        new void Add(T value);
        new void Update(long id, T value);
        void Delete(long id);
    }
}
