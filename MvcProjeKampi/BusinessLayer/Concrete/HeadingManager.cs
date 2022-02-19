using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal) // Yapıcı metodumuz
        {
            _headingDal = headingDal;
        }


        public Heading GetByID(int id) // Bulma işlemi için gerekli metot.
        {

            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter()
        {
            return _headingDal.List(x => x.WriterID ==2);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            heading.HeadingStatus = heading.HeadingStatus == true? false : true;   // Başlık durumunu false veya true yapmak için gerekli kod satırı...
            _headingDal.Update(heading); // Burada normalde silme işlemi olacaktı ama onun yerine A/P yapmak için güncelleme uyguladık.

        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }


    }
}
