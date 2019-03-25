using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Builders
{
    public class MainPageBuilder

    {
        public MainPageBuilder(EntityTypeConfiguration<MainPage> entity)
        {
            entity.HasKey(e => e.Id);
        }
    }
}
