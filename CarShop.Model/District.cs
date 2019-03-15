using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class District:BaseEntity
    {
        public Guid Id { get; set; }
        [Display(Name="İlçe")]
        public string Name { get; set; }
        [Display(Name = "Şehir")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
