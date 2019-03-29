using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Builders
{
    public class OrderProductsBuilder
    {
        public OrderProductsBuilder(EntityTypeConfiguration<OrderProducts> entity)
        {
            entity.HasKey(e => e.Id);           
            entity.HasOptional(e => e.Order).WithMany(c => c.OrderProducts).HasForeignKey(p => p.OrderId).WillCascadeOnDelete(true);
        }
    }
}
