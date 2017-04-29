using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Infrastracture.Daos;
using DomainModel.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace DomainModel.Daos
{
    public class WorkDao : IDao<Item>
    {
        private ItemDbContext _itemDbContext { get; set; }
        public WorkDao(ItemDbContext itemDbContext)
        {
            _itemDbContext = itemDbContext;
        }

        public void Add(Item value)
        {
            var connection = _itemDbContext.Database.GetDbConnection();
            dynamic exObj = connection.Query(@"select * from item");
            ExpandoObject obj = new ExpandoObject();
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Item> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Item Find(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(long id, Item value)
        {
            throw new NotImplementedException();
        }
    }
}
