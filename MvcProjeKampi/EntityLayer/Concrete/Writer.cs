using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Writer // Yazar
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; } // Yazar İsmi

        [StringLength(50)]
        public string WriterSurname { get; set; } // Yazar Soyismi

        [StringLength(250)]
        public string WriterImage { get; set; } // Yazar Resmi

        [StringLength(100)]
        public string WriterAbout { get; set; } // Yazar Hakkında

        [StringLength(200)]
        public string WriterMail { get; set; } // Yazar Mail

        [StringLength(200)]
        public string WriterPassword { get; set; } // Yazar Şifre

        public bool WriterStatus { get; set; } // Yazar Durumu



        public ICollection<Heading> Headings { get; set; }

        public ICollection<Content> Contents { get; set; }

    }
}
