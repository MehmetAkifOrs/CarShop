using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class MainPage : BaseEntity
    {
       
        [Display(Name = "Anasayfa Fotoğrafı")]                
        public String MainPagePhoto { get; set; }
        [Display(Name = "Anasayfa Başlığı")]
        public string MainPageHeader { get; set; }
        [Display(Name = "Anasayfa Açıklaması")]
        public string MainPageDescription { get; set; }

    }
}
