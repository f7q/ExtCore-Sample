using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Infrastracture.Repositorys
{
    public interface IInRepositorys<in T>
    {
        void Add(T value);
        void Update(long id, T value);
    }
}
