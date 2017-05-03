namespace PackageDefaultCustom.Repositorys
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Package.Models;
    using Package.Repositorys;
    using Package.Infrastracture.Repositorys;

    public class ItemDefaultCustomRepository : IRepository<Item>
    {
        private IRepository<Item> _itemRepository { get; set; }
        public ItemDefaultCustomRepository(ItemRepository itemRepository)
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
            return;
        }
        public void Update(long id, Item value)
        {
            _itemRepository.Update(id, value);
            return;
        }
        public void Delete(long id)
        {
            _itemRepository.Delete(id);
            return;
        }
    }
}