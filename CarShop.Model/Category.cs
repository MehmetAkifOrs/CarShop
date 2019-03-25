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
        public Category()
        {
            Products = new HashSet<Product>();            
        }

        [Display(Name = "Kategori Adı")]
        public String Name { get; set; }
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Kategori Simge Fotosu")]
        public String IconPhoto { get; set; }
        [Display(Name = "Kategori Sayfa Fotosu")]
        public String PagePhoto { get; set; }

        public virtual ICollection<Product> Products { get; set; }

       
    }
}
