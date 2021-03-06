﻿using System;
using Microsoft.AspNetCore.Mvc;
using DomainModel.Infrastracture.Services;
using DomainModel.Models;

namespace DomainModel.Controllers
{
    [Route("api/domainmodel/[controller]")]
    public class ItemsController : Controller
    {
        private IService<Item> _itemService { get; set; }

        public ItemsController(IService<Item> itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_itemService.All());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_itemService.Find(id));
        }
        [HttpPost]
        public void Post([FromBody]Item value)
        {
            _itemService.Add(value);
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Item value)
        {
            _itemService.Update(id, value);
        }
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _itemService.Delete(id);
        }
    }
}