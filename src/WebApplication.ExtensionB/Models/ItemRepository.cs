// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace WebApplication.ExtensionB.Models
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
    }
}