using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Country
    {
        public Guid Id { get; set; }
        [Display(Name ="Ülke")]
        public String Name { get; set; }
    
        public virtual ICollection<City> Cities { get; set; }
    }
}
