using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class City
    {
        public Guid Id { get; set; }
        [Display(Name = "Şehir")]
        public string Name { get; set; }
        [Display(Name = "Ülke")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
