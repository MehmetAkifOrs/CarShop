using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Order:BaseEntity
    {
       
        [Display(Name ="Müşteri Adı")]
        public String CustomerFirstName { get; set; }
        [Display(Name = "Müşteri Soyadı")]
        public String CustomerLastName { get; set; }
        [Display(Name = "Ülke")]
        public String CountryName { get; set; }
        [Display(Name = "Şehir")]
        public String CityName { get; set; }
        [Display(Name = "İlçe")]
        public String DistrictName { get; set; }
        [Display(Name = "Adres")]
        public String Address { get; set; }
        [Display(Name = "Telefon")]
        [Phone]
        public String Phone { get; set; }
        [Display(Name = "E-posta")]
        [EmailAddress]
        public String Email { get; set; }
        [Display(Name = "Siparişler")]
        public String Orders { get; set; }
        [Display(Name = "Toplam Tutar")]
        public Decimal TotalPrice { get; set; }


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
