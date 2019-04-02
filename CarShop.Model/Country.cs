using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Country:BaseEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Orders = new HashSet<Order>();
            
        }
       
        [Display(Name ="Ülke")]
        [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String Name { get; set; }
    
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
