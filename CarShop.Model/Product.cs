using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Product:BaseEntity
    {
        public Product()
        {
            Photos = new HashSet<Photo>();
        }
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Foroğraf")]
        public string Photo { get; set; }       
        [Display(Name = "Stok")]
        public int Stock { get; set; }
        [Display(Name = "Fiyat")]
        public Decimal Price { get; set; }
        [Display(Name = "Kategoriler")]
        public Guid? CategoryId { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
