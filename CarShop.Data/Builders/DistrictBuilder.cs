using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Builders
{
    public class DistrictBuilder
    {
        public DistrictBuilder(EntityTypeConfiguration<District> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasOptional(e => e.City).WithMany(e => e.Districts).HasForeignKey(e => e.CityId).WillCascadeOnDelete(true);
        }
    }
}
