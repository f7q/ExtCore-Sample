namespace PackageCustum.Repositorys
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PackageCustum.Models;
    using Package.Infrastracture.Repositorys;

    public class ItemCustumRepository : IRepository<Item>
    {
        private Item2DbContext _itemDbContext { get; set; }
        public ItemCustumRepository(Item2DbContext itemDbContext)
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