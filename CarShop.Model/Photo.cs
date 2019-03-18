using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Photo:BaseEntity
    {

        public String Name { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
