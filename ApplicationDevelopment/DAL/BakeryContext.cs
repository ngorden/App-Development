using ApplicationDevelopment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApplicationDevelopment.DAL
{
    public class BakeryContext : DbContext
    {
        public BakeryContext() : base("DefaultConnection")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}