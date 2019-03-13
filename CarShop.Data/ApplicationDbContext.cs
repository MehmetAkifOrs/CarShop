using CarShop.Data.Builders;
using CarShop.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Posts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductBuilder(modelBuilder.Entity<Product>());
            new CategoryBuilder(modelBuilder.Entity<Category>());            
        }
    }
}
