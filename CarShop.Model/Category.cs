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
        [MaxLength(100)]
        [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String Name { get; set; }
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        [MaxLength(4000)]
        public string Description { get; set; }
        [Display(Name = "Kategori Simge Fotosu")]
        [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String IconPhoto { get; set; }
        [Display(Name = "Kategori Sayfa Fotosu")]
        [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String PagePhoto { get; set; }

        public virtual ICollection<Product> Products { get; set; }

       
    }
}
