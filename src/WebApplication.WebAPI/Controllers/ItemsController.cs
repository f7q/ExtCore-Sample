// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using WebApplication.WebAPI.Models;

namespace WebApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private IItemRepository _itemRepository { get; set; }

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_itemRepository.All());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_itemRepository.Find(id));
        }
        [HttpPost]
        public void Post([FromBody]Item value)
        {
            _itemRepository.Add(value);
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Item value)
        {
            _itemRepository.Update(id, value);
        }
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _itemRepository.Delete(id);
        }
    }
}