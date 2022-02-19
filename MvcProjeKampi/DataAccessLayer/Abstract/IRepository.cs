using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IRepository<T>  // Repository <T> buradaki T'bizim SQL'tarafından gönderdiğimiz herhangi bir tablomuzu karşılar. 
                                   // Yani bizim SQL'den Kategori,Başlık,Yazar vs tüm tablolarımızı T' karşılayacak.
    {
        List<T> List();
        void Insert(T p); // Insert için parametre almamız gerekiyor bunuda T'den parametreyi alacağız. Diğerlerinde de aynı şekilde olacaktır.
        void Update(T p);

        T Get(Expression<Func< T, bool>> filter); // Değer bulma için gerekli metot. Örneğin silme işlemi işlemi için gidip ID'yi bulacak. 

        void Delete(T p);

        List<T> List(Expression<Func<T, bool>> filter);   // Şartlı listeleme yapmak için gerekli metot...


    }
}
