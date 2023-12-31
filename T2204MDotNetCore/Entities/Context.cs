﻿using Microsoft.EntityFrameworkCore;
namespace T2204MDotNetCore.Entities
{
    public class Context :DbContext
    {

        public Context(DbContextOptions options ) :base(options)
        {
        }
        // them chieu product sang db (tao bang)
        public DbSet<Product> Products { get; set;}

        public DbSet<Category> Categories { get; set;}

        public DbSet<Brand> Brands { get; set;}
    }
}
