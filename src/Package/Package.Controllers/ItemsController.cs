using System;
using Microsoft.AspNetCore.Mvc;
using Package.Infrastracture.Services;
using Package.Models;

namespace Package.Controllers
{
    [Route("api/package/[controller]")]
    public class ItemsController : Controller
    {
        private IService<Item> _itemService { get; set; }

        public ItemsController(IService<Item> itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_itemService.All());
        }
        [HttpGet("{id}")]
        public virtual IActionResult Get(long id)
        {
            return Ok(_itemService.Find(id));
        }
        [HttpPost]
        public virtual void Post([FromBody]Item value)
        {
            _itemService.Add(value);
        }
        [HttpPut("{id}")]
        public virtual void Put(long id, [FromBody]Item value)
        {
            _itemService.Update(id, value);
        }
        [HttpDelete("{id}")]
        public virtual void Delete(long id)
        {
            _itemService.Delete(id);
        }
    }
}