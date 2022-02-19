using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; } // Gönderici Mail

        [StringLength(50)]
        public string ReceiverMail { get; set; } // Alıcı Mail

        [StringLength(100)]
        public string Subject { get; set; } // Konu
       
        public string MessageContent { get; set; } // Mesaj içerik
        public DateTime MessageDate { get; set; } // Mesaj Tarihi



    }
}
