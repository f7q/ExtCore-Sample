using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Infrastracture.Daos
{
    public interface IInDaos<in T>
    {
        void Add(T value);
        void Update(long id, T value);
    }
}
