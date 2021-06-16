using Akkoc.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Akkoc.Utils;

namespace Akkoc.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [ValidateInput(false)]
        public ActionResult Index()
        {
            var entities = new AkkocContext();
            var site = entities.SiteStatics.FirstOrDefault();
            ViewBag.Location = site.Location;
            return View();
        }

        [HttpPost]
        public JsonResult SendMessage(Akkoc.Domain.POCO.Message message)
        {
            if(!ModelState.IsValid)
            {
                return Json(new
                {
                    Status = "error",
                    Message = ModelState.ParseModelErrors()
                });
            }

            if(string.IsNullOrEmpty(Request.Form["g-recaptcha-response"]))
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Robot olmadığınıza dair onay kutusunu işaretleyin."
                });
            }

            AkkocContext entities = new AkkocContext();

            try
            {
                //mesajı veritabanına kaydet                
                entities.Messages.Add(message);
                entities.SaveChanges();

                //Mesaj gönderildiğine dair cookie'yi kişinin makinesinde saklayalım.
                HttpCookie cookie = new HttpCookie("sendMessage", "ok");
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);

                //kullanıcıya işlem başarılı mesajı gönder
                return Json(new
                {
                    Status = "ok",
                    Message = "Mesajınız başarıyla kaydedildi. En kısa zamanda size dönüş yapılacaktır."
                });
            }
            catch (Exception ex)
            {
                var logError = new Domain.POCO.LogError
                {
                    ActionName="SendMessage",
                    ControllerName="Contact",
                    CreateUser="guest",
                    CreateDate=DateTime.Now,
                    IsAjaxRequest=true,
                    LastupDate=DateTime.Now,
                    LastupUser="guest",
                    Message=ex.Message,
                    EntityName="Message"
                };
                entities.LogErrors.Add(logError);
                entities.SaveChanges();
                return Json(new
                {
                    Status = "error",
                    Message = "Kayıt esnasında bir hata oluştu. Hata No:"+logError.Id
                });
            }
            
        }
    }
}