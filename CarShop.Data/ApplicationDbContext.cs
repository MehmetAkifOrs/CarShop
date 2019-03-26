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
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<MainPage> MainPages { get; set; }
        public virtual DbSet<ContactPage> ContactPages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductBuilder(modelBuilder.Entity<Product>());
            new CategoryBuilder(modelBuilder.Entity<Category>());
            new AboutBuilder(modelBuilder.Entity<About>());
            new MainPageBuilder(modelBuilder.Entity<MainPage>());
            new ContactPageBuilder(modelBuilder.Entity<ContactPage>());
            new OrderBuilder(modelBuilder.Entity<Order>());
            new CountryBuilder(modelBuilder.Entity<Country>());
            new CityBuilder(modelBuilder.Entity<City>());
            new DistrictBuilder(modelBuilder.Entity<District>());
            new PhotoBuilder(modelBuilder.Entity<Photo>());
            new CartBuilder(modelBuilder.Entity<Cart>());
            new LocationBuilder(modelBuilder.Entity<Location>());

        }
    }
}
