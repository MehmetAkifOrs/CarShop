using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Builders
{
    public class LocationBuilder
    {
        public LocationBuilder(EntityTypeConfiguration<Location> entity)
        {
            entity.HasKey(e => e.Id);
        }
    }
}
