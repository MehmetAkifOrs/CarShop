using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Builders
{
    public class PhotoBuilder
    {
        public PhotoBuilder(EntityTypeConfiguration<Photo> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.HasOptional(e => e.Product).WithMany(c => c.Photos).HasForeignKey(p => p.ProductId);
        }
    }
}
