﻿using System;
using System.Collections.Generic;

namespace Package.Infrastracture.Services
{
    public interface IService<T> : IInService<T>, IOutService<T>
    {
        new IEnumerable<T> All();
        new T Find(long id);
        new void Add(T value);
        new void Update(long id, T value);
        void Delete(long id);
    }
}
