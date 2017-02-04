﻿using AutoQueryable.Sample.EfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoQueryable.Sample.EfCore.Contexts
{
    public class AutoQueryableContext : DbContext
    {
        public AutoQueryableContext(DbContextOptions<AutoQueryableContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
}