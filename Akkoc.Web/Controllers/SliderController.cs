using Akkoc.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akkoc.Utils;
using Akkoc.Domain.POCO;

namespace Akkoc.Web.Controllers
{
    public class SliderController : Controller
    {
        public ActionResult Detail(string title)
        {            
            var entities = new AkkocContext();
            var slider = entities.Sliders.ToList().SingleOrDefault(s => s.Title.ToLegalString() == title);
            ViewBag.Title = slider.Title;
            return View(slider);
        }
    }
}