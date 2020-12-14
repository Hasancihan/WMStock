using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WMStock.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WMEnvanter.Context
{
    public class ProductManagementContext : DbContext
    {

        public ProductManagementContext() : base("ProductManagementContextDB")
        { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Personal> Personals { get; set; }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Modal> Modals { get; set; }

        public DbSet<Brand> Brands { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}