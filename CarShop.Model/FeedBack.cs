using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class FeedBack : BaseEntity
    {
        [Display(Name = "Ad Soyad")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public string FullName { get; set; }
        [Display(Name = "E-posta")]
        [EmailAddress]
        [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public string Email { get; set; }
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Display(Name = "Mesaj")]
        public string Message { get; set; }



    }
}
