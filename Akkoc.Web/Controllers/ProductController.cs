using Akkoc.DataContext;
using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akkoc.Utils;

namespace Akkoc.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var entities = new AkkocContext();
            var categoriesWithProducts = entities.Categories.Include("Products").ToList();
            ViewBag.Title = "Ürünlerimiz";
            return View(categoriesWithProducts);
        }

        public ActionResult Detail(string name)
        {
            var entities = new AkkocContext();
            var product = entities.Products.Include("Category").ToList().SingleOrDefault(p => p.Name.ToLegalString() == name);
            ViewBag.Title = product.Name;
            return View(product);
        }
    }
}