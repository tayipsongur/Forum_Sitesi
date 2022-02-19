using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class About // Hakkında
    {
        [Key]
        public int AboutID { get; set; } 

        [StringLength(1000)]
        public string AboutDeatils1 { get; set; } // Hakında Detay1

        [StringLength(1000)]
        public string AboutDeatils2 { get; set; } // Hakkında Detay2
        [StringLength(100)]
        public string AboutImage1 { get; set; } // Hakkında Resim1

        [StringLength(100)]
         public string AboutImage2 { get; set; } // Hakkında Resim2

        public bool AboutStatus { get; set; }

    } 
}
