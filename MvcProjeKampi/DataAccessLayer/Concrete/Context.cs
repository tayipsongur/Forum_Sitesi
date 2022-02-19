using EntityLayer.Concrete; // Entity Layer katmanındaki verilere ulaşabilmek için referans aldık.
using System;
using System.Collections.Generic;
using System.Data.Entity; // DbContext'i kullanabilmek için gerekli kütüphane
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }


        // DbSet<..> bunlar sınıf isimlerimiz. "s" takısı gelenler ise SQL'e yansıyacak tablo isimleri

    }
}
