using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        // [Display(Name = "Ürünler")]
        //public Guid? ProductId { get; set; }
        //public virtual Product Product { get; set; }
    }
}
