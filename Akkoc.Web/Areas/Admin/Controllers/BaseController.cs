using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Akkoc.Utils;
using Akkoc.DataContext;
using Akkoc.Domain.POCO;
using System.Data.Entity.Validation;

namespace Akkoc.Web.Areas.Admin
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!ModelState.IsValid)
            {
                var controller = filterContext.RouteData.Values["controller"].ToString();
                var action = filterContext.RouteData.Values["action"].ToString();
                object model = filterContext.Controller.TempData["model"];

                //istekte şu ana kadar üretilen TempData bilgisini al
                var oldTempData = filterContext.Controller.TempData;
                //hata mesajını bu tempdata koleksiyonuna ekle
                oldTempData.Add("error", ModelState.ParseModelErrors());

                filterContext.Result = new ViewResult
                {
                    ViewName = action,
                    TempData = oldTempData,
                    ViewData = new ViewDataDictionary
                    {
                        Model = model
                    }
                };
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //1-Model varsa modeli elde etmeliyim
            //2-Şu an hata oluşan controller ve action hangisiyse onları
            //tespit edebilmeliyim

            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            object model = filterContext.Controller.TempData["model"];

            //İstek ajax isteği mi?
            bool isAjaxRequest = Request["X-Requested-With"] == "XMLHttpRequest";

            //Hatayı sıfdırla
            filterContext.ExceptionHandled = true;

            AkkocContext entities = new AkkocContext();

            //Hata mesajını oluştur
            var message = filterContext.Exception.Message;

            if (filterContext.Exception is DbEntityValidationException)
                message = (filterContext.Exception as DbEntityValidationException).ParseDbEntityValidationErrors();

            //Hatayı kaydetmek üzere modeli oluştur.
            entities.LogErrors.Add(new LogError
            {
                ActionName = action,
                ControllerName = controller,
                EntityName = (model!=null)?model.GetType().Name:"null",
                RecId = (model!=null&&model is Base)?(model as Base).Id:0,
                LastupUser = "user1",
                Message = message.Length>255?message.Substring(0,254):message,
                IsAjaxRequest = isAjaxRequest
            });
            entities.SaveChanges();

            //Çağrı ajax çağrısıdır.
            if (isAjaxRequest)
            {
                //Ajax çağrısını yapan jquery'ye Json sonucu gönder
                JsonResult jsonResult = new JsonResult();
                jsonResult.Data = new
                {
                    Status = "error",
                    Message = "İşlem sırasında bir hata oluştu.<br/>" + message
                };
                filterContext.Result = jsonResult;
            }
            else
            {
                //normal istektir. Kullanıcıyı kayıt yapmaya çalıştığı
                //View'e gönder.
                ViewResult viewResult = new ViewResult
                {
                    ViewName = action,
                    TempData = new TempDataDictionary
                    {
                        { "error",message }
                    },
                    ViewData = new ViewDataDictionary
                    {
                        Model = model
                    }
                };
                filterContext.Result = viewResult;
            }


        }

    }
}