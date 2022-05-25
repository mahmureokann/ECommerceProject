using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Map;

namespace DataAccess.Context
{
    public class ECommerceContext:DbContext
    {
        public ECommerceContext()
        {
            Database.Connection.ConnectionString = "server=KDK-101-PC05-YZ;database=ECommerceDB;uid=sa;pwd=123";
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
