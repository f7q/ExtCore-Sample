using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Infrastracture.Services
{
    public interface IInService<in T>
    {
        void Add(T value);
        void Update(long id, T value);
    }
}
