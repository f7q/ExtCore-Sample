// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

namespace PackageDefaultCustom.Models
{
    public class Item2DbContext : DbContext
    {
        public Item2DbContext(DbContextOptions<Item2DbContext> options) :base(options)
        { }
        public DbSet<Item> Items { get; set; }
    }
}