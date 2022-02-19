using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager cm = new ContentManager(new EfContentDal()); 

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)  // Başlığa göre içerikleri getir
        {
            var contentvalues = cm.GetlistByHeadingID(id);

            return View(contentvalues);
        }
    }
}