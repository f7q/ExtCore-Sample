using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Infrastracture.Services
{
    public interface IOutService<out T>
    {
        IEnumerable<T> All();
        T Find(long id);
    }
}
