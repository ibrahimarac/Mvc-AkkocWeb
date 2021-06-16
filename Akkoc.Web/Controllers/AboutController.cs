using Akkoc.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akkoc.Web.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Title = "Biz Kimiz";
            var entities = new AkkocContext();
            var model = entities.SiteStatics.FirstOrDefault();
            return View(model);
        }
    }
}