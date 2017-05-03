using System;
using Microsoft.AspNetCore.Mvc;
using Package.Infrastracture.Controllers;
using Package.Infrastracture.Services;
using Package.Models;

namespace Package.Controllers
{
    public class ItemsController : ControllerBase
    {
        protected IService<Item> _itemService { get; set; }

        public ItemsController(IService<Item> itemService)
        {
            _itemService = itemService;
        }

        public virtual IActionResult Get()
        {
            return Ok(_itemService.All());
        }
        
        public virtual IActionResult Get(long id)
        {
            return Ok(_itemService.Find(id));
        }
        
        public virtual void Post([FromBody]Item value)
        {
            _itemService.Add(value);
        }
        
        public virtual void Put(long id, [FromBody]Item value)
        {
            _itemService.Update(id, value);
        }
        
        public virtual void Delete(long id)
        {
            _itemService.Delete(id);
        }
    }
}