using Akkoc.DataContext;
using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Akkoc.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //[OutputCache(Duration =3600, Location = OutputCacheLocation.Client)]
        public ActionResult Slider()
        {
            var entities = new AkkocContext();
            var slider = entities.Sliders.Where(s=>s.IsActive).OrderByDescending(s=>s.Order);
            return PartialView("_Slider", slider);
        }

        public ActionResult Static()
        {
            var entities = new AkkocContext();
            var statics = entities.SiteStatics.First();
            return PartialView("_Footer", statics);
        }

        public ActionResult Test()
        {
            return View();
        }

        //public ContentResult GetCapcha(int length)
        //{
        //    string[] capchaChars = new string[length];
        //    for (int i = 0; i < length; i++)
        //    {
        //        var character = new Random().Next(0, 9).ToString();
        //        capchaChars[i] = character;                
        //    }
        //    //güvenlik resmini oluşturacak sayılar birleştiriliyor.
        //    var capcaString = string.Concat(capchaChars);

        //    Bitmap image = new Bitmap(0, 0);
        //    Graphics.FromImage

        //}
    }
}