// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
namespace WebApplication.WebAPI.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> All();
        Item Find(long id);
        void Add(Item value);
        void Update(long id, Item value);
        void Delete(long id);
    }
}