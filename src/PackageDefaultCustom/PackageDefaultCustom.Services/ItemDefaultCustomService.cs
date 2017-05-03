using System;
using Package.Models;
using Package.Infrastracture.Services;
using Package.Infrastracture.Repositorys;
using System.Collections.Generic;

namespace PackageDefaultCustom.Services
{
    public class ItemDefaultCustomService : IService<Item>
    {
        private IService<Item> _itemService { get; set; }

        public ItemDefaultCustomService(IService<Item> itemService)
        {
            _itemService = itemService;
        }

        public IEnumerable<Item> All()
        {
            return _itemService.All();
        }

        public Item Find(long id)
        {
            return _itemService.Find(id);
        }

        public void Add(Item value)
        {
            _itemService.Add(value);
        }

        public void Update(long id, Item value)
        {
            _itemService.Update(id, value);
        }

        public void Delete(long id)
        {
            _itemService.Delete(id);
        }
    }
}