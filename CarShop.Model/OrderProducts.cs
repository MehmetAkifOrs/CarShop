using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class OrderProducts:BaseEntity
    {
        [Display(Name = "Ürün Adı")]
        public string  ProductName { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Ücret")]
        public decimal Priece { get; set; }
        [Display(Name = "Toplam Ücret")]
        public decimal TotalPrice { get; set; }

        [Display(Name ="Sipariş")]
        public Guid? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
