﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace WebApplication.WebAPI.Models
{
    public class ItemRepository : IItemRepository
    {
        private ItemDbContext _itemDbContext { get; set; }
        public ItemRepository(ItemDbContext itemDbContext)
        {
            _itemDbContext = itemDbContext;
        }
        public IEnumerable<Item> All()
        {
            return _itemDbContext.Items.OrderBy(i => i.Name);
        }
        public Item Find(long id)
        {
            return _itemDbContext.Items.Where(i => i.Id == id).First();
        }
        public void Add(Item value)
        {
            _itemDbContext.Items.Add(value);
            _itemDbContext.SaveChanges();
            return;
        }
        public void Update(long id, Item value)
        {
            _itemDbContext.Items.Update(value);
            _itemDbContext.SaveChanges();
            return;
        }
        public void Delete(long id)
        {
            var value =_itemDbContext.Items.Where(i => i.Id == id).First();
            _itemDbContext.Items.Remove(value);
            _itemDbContext.SaveChanges();
            return;
        }
    }
}