using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Builders
{
    public class ContactPageBuilder

    {
        public ContactPageBuilder(EntityTypeConfiguration<ContactPage> entity)
        {
            entity.HasKey(e => e.Id);
        }
    }
}
