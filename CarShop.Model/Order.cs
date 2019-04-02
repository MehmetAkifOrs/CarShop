using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        [Display(Name = "Müşteri Adı")]
        [MaxLength(100)]
        //[Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String CustomerFirstName { get; set; }
        [Display(Name = "Müşteri Soyadı")]
        [MaxLength(100)]
       // [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String CustomerLastName { get; set; }
        [Display(Name = "Ülke")]
        [MaxLength(100)]
        //[Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String CountryName { get; set; }
        [MaxLength(100)]
        //[Required(ErrorMessage = "Bu Alan Zorunludur !")]
        [Display(Name = "Şehir")]
        public String CityName { get; set; }
        [Display(Name = "İlçe")]
        [MaxLength(100)]
        //[Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String DistrictName { get; set; }
        [Display(Name = "Adres")]
        [MaxLength(1000)]
        [Required(ErrorMessage = "Bu Alan Zorunludur !")]
        public String Address { get; set; }
        [Display(Name = "Telefon")]
        [Phone]
        [MaxLength(100)]
       // [Required(ErrorMessage = "Bu Alan Zorunludur !")]
       // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                  // ErrorMessage = "Lütfen uygun formatta giriş yapınız")]
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

