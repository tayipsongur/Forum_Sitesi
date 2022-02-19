using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        // Kategori Ekleme İşlemi
        public void CategoryAdd(Category category)
        {

            _categoryDal.Insert(category);
            
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);

        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);

        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id); // int id ile parametre gönderiyoruz. Bu parametrede CategoryID ile eşit olmalı...
        }

        public List<Category> GetList()  // Kategori Listeleme...
        {

            return _categoryDal.List();
        }
    }
}
