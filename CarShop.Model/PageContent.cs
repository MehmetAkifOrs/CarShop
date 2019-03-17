using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Model
{
    public class PageContent:BaseEntity
    {
       
        [Display(Name = "Kategori Sayfa Fotoğrafı")]
        public String CategoryPagePhoto { get; set; }
        [Display(Name = "Kategori Sayfa Başlığı")]
        public string CategoryPageHeader { get; set; }
        [Display(Name = "Kategori Sayfa Açıklaması")]
        public string CategoryPageDescription { get; set; }
        [Display(Name = "Hakkımızda Sayfa Fotoğrafı")]
        public String AboutPagePhoto { get; set; }
        [Display(Name = "Hakkımızda Sayfa Başlığı")]
        public string AboutPageHeader { get; set; }
        [Display(Name = "Hakkımızda Sayfa Açıklaması")]
        public string AboutPageDescription { get; set; }

    }
}
