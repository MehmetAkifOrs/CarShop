using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Category:BaseEntity
    {
        [Display(Name = "Kategori Adı")]
        public String Name { get; set; }
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
