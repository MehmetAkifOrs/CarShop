using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class City:BaseEntity
    {

        public City()
        {
            Districts = new HashSet<District>();
            Orders = new HashSet<Order>();

        }
        
        [Display(Name = "Şehir")]
        public string Name { get; set; }
        [Display(Name = "Ülke")]
        public Guid? CountryId { get; set; }
        [ForeignKey("CountryId")]
        [Display(Name = "Ülke")]
        public virtual Country Country { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
