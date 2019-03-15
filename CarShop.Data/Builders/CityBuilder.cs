using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Builders
{
    public class CityBuilder
    {
        public CityBuilder(EntityTypeConfiguration<City> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasOptional(e => e.Country).WithMany(e => e.Cities).HasForeignKey(e => e.CountryId);
        }
    }
}
