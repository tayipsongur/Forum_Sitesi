using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class  // Göndereceğimiz T değerleri bir class olma şartını yazdık.
    {
        Context c = new Context();

        DbSet<T> _obcejt;  // DbSet<T> içindeki T'nin yani gelecek sınıfın ne olduğunu bilmediğimiz için yapıcı metodu aşağıda tanımladık.

        public GenericRepository()
        {
            _obcejt = c.Set<T>();  // Context'e bağlı olarak gönderilen T'değeri _object'e verdik.Yani dışarıdan hangi sınıfı gönderdiysek _obcejt o olacak.
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;

          //  _obcejt.Remove(p); Entity State ile silme işlemi yaptığımız için bu satıra artık ihityacımız kalmadı
            c.SaveChanges();

        }


        // Filtreleme işlemleri için metot...
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _obcejt.SingleOrDefault(filter); // Burada ID'ye göre istediğimiz değeri bulmak için komut yazdık. örneğin, ID'si 5 olan yazarı getir dedik bu metotu kullanacağız.
        }

        public void Insert(T p)
        {
            var AddedEntity = c.Entry(p);     // Ekleme işlemini Entity State ile gerçekleştirdik.
            AddedEntity.State = EntityState.Added;
          //  _obcejt.Add(p); Entity State kullandığımız için artık bu satırdaki koda ihtiyacımız kalmadı...
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _obcejt.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {


            return _obcejt.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified; 
            c.SaveChanges();
            
        }
    }
}
