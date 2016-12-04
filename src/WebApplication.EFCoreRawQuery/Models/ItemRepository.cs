// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApplication.EFCoreRawQuery.Models
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
            var sql = @"
SELECT Id, Name
FROM Item 
WHERE 
Name IN ('Electro', 'Nitro')
";
            // Execute a query.
            //var dr = await _itemDbContext.Database.ExecuteSqlQueryAsync(sql);
            var dr = _itemDbContext.Database.ExecuteSqlQuery(sql);
            var result = dr.DbDataReader.GetEnumerator();
            // Output rows.
            while (dr.DbDataReader.Read())
                System.Console.Write("{0}\t{1}} \n", dr[0], dr[1]);

            // Don't forget to dispose the DataReader! 
            dr.Dispose();
            return result.;
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