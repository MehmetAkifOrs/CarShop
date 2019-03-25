using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Location:BaseEntity
    {
        [Display(Name = "Ülke")]
        public Guid? CountryId { get; set; }
        [Display(Name = "Ülke")]
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }


        [Display(Name = "Şehir")]
        public Guid? CityId { get; set; }
        [ForeignKey("CityId")]
        [Display(Name = "Şehir")]
        public virtual City City { get; set; }

        [Display(Name = "İlçe")]
        public Guid? DistrictId { get; set; }
        [Display(Name = "İlçe")]
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

    }
}
