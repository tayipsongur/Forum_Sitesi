using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var messagevalues = mm.GetByID(id);

            return View(messagevalues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messagevalues = mm.GetByID(id);

            return View(messagevalues); 
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();


        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            
            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();
       
        }


      
        public ActionResult DeleteMessage(int id)
        {

            var mesajsil = mm.GetByID(id);
            mm.MessageDelete(mesajsil);




      // Katmanlı Mimari yapısına uygun olmayan controllerda yapılan silme işlemi 
            //Context db = new Context();

            //var mesajsil = db.Messages.Find(id);
            //db.Messages.Remove(mesajsil);
            //db.SaveChanges();


            return RedirectToAction("Inbox");
        }


       
      
    }
}