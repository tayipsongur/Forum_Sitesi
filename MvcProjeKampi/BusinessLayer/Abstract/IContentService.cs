using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContentService
    {
        List<Content> GetList();

        List<Content> GetlistByHeadingID(int id); // GetListByID: ID'ye göre bütün listeyi döndürür.

        void ContentAdd(Content content);

        Content GetByID(int id);  // GetByID : ID'ye göre bir tane değer döndürüyor.

        void ContentDelete(Content content);

        void ContentUpdate(Content content);
    }
}
