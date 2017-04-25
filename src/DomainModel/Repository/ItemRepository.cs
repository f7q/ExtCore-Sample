using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Models;
using DomainModel.Infrastracture.Repositorys;

namespace DomainModel.Repositorys
{
    public class ItemRepository : IRepository<Item>
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
            var value = _itemDbContext.Items.Where(i => i.Id == id).First();
            _itemDbContext.Items.Remove(value);
            _itemDbContext.SaveChanges();
            return;
        }
    }
}