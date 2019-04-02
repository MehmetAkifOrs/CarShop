using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class ContactPage : BaseEntity
    {

        [Display(Name = "İletişim Sayfası Fotoğrafı")]
       // [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String ContactPagePhoto { get; set; }
        [Display(Name = "İletişim Bilgileri")]
        
        public string ContactPageInformation { get; set; }
        [Display(Name = "Adres")]

        public string ContactPageAddress { get; set; }
        [Display(Name = "Pazarlama Telefon")]
        public string ContactPageMarketingPhone { get; set; }
        [Display(Name = "Pazarlama Eposta")]
        public string ContactPageMarketingEmail { get; set; }
        [Display(Name = "Nakliye Telefon")]
        public string ContactPageShippingPhone { get; set; }
        [Display(Name = "Nakliye Eposta")]
        public string ContactPageShippingEmail { get; set; }
        [Display(Name = "Bilgi Telefon")]
        public string ContactPageInformationPhone { get; set; }
        [Display(Name = "Bilgi Eposta")]
        public string ContactPageInformationEmail { get; set; }

    }
}
