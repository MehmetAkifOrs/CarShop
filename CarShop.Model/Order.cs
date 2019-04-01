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
        public Order()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }           
       
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

        [Display(Name = "Toplam Tutar")]
        public Decimal? TotalPrice { get; set; }
        [Display(Name = "Gönderen Adı Soyadı")]
        public String SenderName { get; set; }

        [Display(Name = "Gönderen Tc No")]
        public String IdNumber { get; set; }
        [Display(Name = "Gönderen Banka Adı")]
        public String BankName { get; set; }

        [Display(Name = "Gönderen Iban No")]
        public String BankIban { get; set; }

        public virtual ICollection<OrderProducts> OrderProducts { get; set; }

    }
}
