using System;
using Package.Models;
using Package.Infrastracture.Services;
using Package.Infrastracture.Repositorys;
using System.Collections.Generic;

namespace Package.Services
{
    public class ItemService : IService<Item>
    {
        private IRepository<Item> _itemRepository { get; set; }

        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> All()
        {
            return _itemRepository.All();
        }

        public Item Find(long id)
        {
            return _itemRepository.Find(id);
        }

        public void Add(Item value)
        {
            _itemRepository.Add(value);
        }

        public void Update(long id, Item value)
        {
            _itemRepository.Update(id, value);
        }

        public void Delete(long id)
        {
            _itemRepository.Delete(id);
        }
    }
}