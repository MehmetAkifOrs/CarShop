using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class District:BaseEntity
    {
       
        [Display(Name="İlçe")]
        [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public string Name { get; set; }
        [Display(Name = "Şehir")]
        public Guid? CityId { get; set; }
        [ForeignKey("CityId")]
        [Display(Name = "Şehir")]
        public virtual City City { get; set; }
    }
}
