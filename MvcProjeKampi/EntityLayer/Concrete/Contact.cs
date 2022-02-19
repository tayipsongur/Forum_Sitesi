﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Contact // İletişim 
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; } // İsim 
        [StringLength(50)]
        public string UserMail { get; set; } // Mail

        [StringLength(50)]
        public string Subject { get; set; } // Konu

        public DateTime ContactDate { get; set; }

        public string Message { get; set; } // Mesaj

    }
}
