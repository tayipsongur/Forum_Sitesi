using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {

          Context c = new Context(); // Context sınıfımızdan c isminde bir nesne türettik.

         DbSet<Category>  _obcejt;   // DbSet türünde bir obcejt isminde bir nesne türettik. İçerisine de üzerinde çalıştığımız sınıfımızı yazdık.
                                     // _object bizim category sınıfımızın değerlerini tutuyor. 
         
        public void Delete(Category p)
        {
            _obcejt.Remove(p);  // parametreden gelen değeri sınıfımız içerisinden çıkart dedik.
            c.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
            _obcejt.Add(p);  // _object içerisinde bulunan sınıfıma "p" den gelen değeri ekle dedik.

            c.SaveChanges(); // context'te değişiklikleri kaydet.
        }

        public List<Category> List()
        {

            return _obcejt.ToList();  
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges();   // Güncellemede sadece kaydet diyoruz. Çünkü güncelleme işleminden önce yeni halini yansıtacağız.
        }
    }
}
