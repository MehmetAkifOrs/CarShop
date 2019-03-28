using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Cart : BaseEntity
    {
        [Display(Name = "Adet")]
        public int Piece { get; set; }

        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }                
        
        [Display(Name = "Fiyat")]
        public Decimal Price { get; set; }

        [Display(Name = "Ürün Fotosu")]
        public String CartProductPhoto { get; set; }

        [Display(Name = "Ürünler")]
        public Guid? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
