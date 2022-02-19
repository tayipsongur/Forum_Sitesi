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
    public class ImageFileManager : IImageFileService
    {

        IImageFileDal _imagefileDal;

        public ImageFileManager(IImageFileDal imagefileDal)
        {
            _imagefileDal = imagefileDal;
        }

        public ImageFile GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
            return _imagefileDal.List();
        }

        public void ImageFileAdd(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageFileDelete(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageFileUpdate(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
