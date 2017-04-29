using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Infrastracture.Daos
{
    public interface IOutDaos<out T>
    {
        IEnumerable<T> All();
        T Find(long id);
    }
}