using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Order:BaseEntity
    {
        public Guid Id { get; set; }
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
    }
}
