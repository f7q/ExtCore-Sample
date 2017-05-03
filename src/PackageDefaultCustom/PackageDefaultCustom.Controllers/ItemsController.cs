
namespace PackageDefaultCustom.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Package.Controllers;
    using Package.Infrastracture.Services;

    using Item = Package.Models.Item;

    [Route("api/package/[controller]")]
    public class ItemsController : Package.Controllers.ItemsController
    {
        public ItemsController(IService<Item> itemService) : base(itemService)
        {
        }

        [HttpGet]
        public override IActionResult Get()
        {
            return base.Get();
        }

        [HttpGet("{id}")]
        public override IActionResult Get(long id)
        {
            return base.Get(id);
        }

        [HttpPost]
        public override void Post([FromBody]Item value)
        {
            base.Post(value);
        }

        [HttpPut("{id}")]
        public override void Put(long id, [FromBody]Item value)
        {
            base.Put(id, value);
        }

        [HttpDelete("{id}")]
        public override void Delete(long id)
        {
            base.Delete(id);
        }
    }
}