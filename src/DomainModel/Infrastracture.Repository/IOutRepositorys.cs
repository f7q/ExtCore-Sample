using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Infrastracture.Repositorys
{
    public interface IOutRepositorys<out T>
    {
        IEnumerable<T> All();
        T Find(long id);
    }
}
