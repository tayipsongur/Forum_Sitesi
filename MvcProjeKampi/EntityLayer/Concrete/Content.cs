using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Content // İçerik
    {
        [Key]
        public int ContentID { get; set; } // İçerik ID

        [StringLength(1000)]
        public string ContentValue { get; set; } // İçerik Metni
        public DateTime ContentDate { get; set; } // İçeriğin Tarihi

        public bool ContentStatus { get; set; } // Silme işlemi yerine aktif/pasif kullanmak için gerekli durum propertysi

        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        public int? WriterID { get; set; } // Writer ID boş olabilir anlamında  ( int? ) 
        public virtual Writer Writer { get; set; }

    }
}
