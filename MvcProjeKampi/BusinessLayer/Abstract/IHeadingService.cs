using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetList();

        List<Heading> GetListByWriter(); // Yazara göre başlıkları getirmek için oluşturduk. Parametreli bir şartlı listeleme metodu.
        void HeadingAdd(Heading heading);

        Heading GetByID(int id);

        void HeadingDelete(Heading heading );

        void HeadingUpdate(Heading heading);
    }
}
