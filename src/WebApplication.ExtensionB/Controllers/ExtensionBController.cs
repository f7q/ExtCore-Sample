// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using WebApplication.ExtensionB.ViewModels.ExtenstionB;
using WebApplication.ExtensionB.Models;

namespace WebApplication.ExtensionB.Controllers
{
    public class ExtensionBController : Controller
    {
        private IItemRepository _itemRepository { get; set; }

        public ExtensionBController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ActionResult Index()
        {
            return this.View(new IndexViewModelBuilder().Build(_itemRepository.All()));
        }
    }
}