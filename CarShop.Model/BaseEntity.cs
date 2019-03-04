using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class BaseEntity
    {
        
        public Guid Id { get; set; }
        [Display(Name = "Ekleyen kişi")]
        public string CreatedBy { get; set; }
        [Display(Name = "Eklenme Zamanı")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Güncelleyen kişi")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Güncellenme Zamanı")]
        public DateTime UpdatedAt { get; set; }
        
    }
}
