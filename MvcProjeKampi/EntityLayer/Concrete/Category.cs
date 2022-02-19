using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Category // Kategori
    {
        [Key]
        public int CategoryID { get; set; } 
        [StringLength(50)]
        public string CategoryName { get; set; } // Kategori İsmi

        [StringLength(200)]
         public string CategoryDescription { get; set; } // Kategori Açıklama
        public bool CategoryStatus { get; set; } // Kategori Durumu (Aktif-Pasif Kontrolü için)


        public ICollection<Heading> Headings { get; set; }  // Bir kategorinin birden fazla başlığı olabilir...Bire Çok ilişki

    }
}
