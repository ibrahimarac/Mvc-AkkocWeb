using Akkoc.DataContext;
using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Akkoc.Utils;
using System.Data.Entity;
using System.Web.Security;

namespace Akkoc.Web.Areas.Admin.Controllers
{
    //Authentication    Doğrulama
    //Authorization     Rol kontrolü - Yetkilendirme

    [CheckUser(Roles ="admin,user")]
    public class CategoryController : BaseController
    {        
        public ActionResult Create()
        {
            ViewBag.Title = "Yeni Kategori";
            return View(new Category { Order = 0 });
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            AkkocContext entities = new AkkocContext();
            
            entities.Categories.Add(category);
            entities.SaveChanges();
            TempData["success"] = "Kategori başarıyla eklendi.";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Kategori Güncelle";
            AkkocContext entities = new AkkocContext();
            var categoryInDb = entities.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryInDb == null)
            {
                TempData["error"] = "Böyle bir kategori bulunamadı";
                return RedirectToAction("List");
            }
            return View(categoryInDb);
        }

        [HttpPost]        
        public ActionResult Edit([Bind(Exclude ="CreateUser")]Category category)
        {
            AkkocContext entities = new AkkocContext();

            var categoryInDb = entities.Categories.SingleOrDefault(c => c.Id == category.Id);

            //if (entities.Entry(category).State == EntityState.Detached)
            //    entities.Categories.Attach(category);
            //category.CreateUser = categoryInDb.CreateUser;
            //entities.Entry(category).State = EntityState.Modified;
            
            categoryInDb.IsActive = category.IsActive;
            categoryInDb.Name = category.Name;
            categoryInDb.Order = category.Order;
            categoryInDb.Description = category.Description;

            entities.SaveChanges();
            TempData["success"] = "Kategori başarıyla güncellendi.";
            return RedirectToAction("List");
        }


        public ActionResult List()
        {
            ViewBag.Title = "Kategori Listesi";
            AkkocContext entities = new AkkocContext();
            var categories = entities.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            AkkocContext entities = new AkkocContext();
            var categoryInDb = entities.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryInDb == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen id değerine sahip bir kayıt bulunamadı."
                });
            }

            entities.Categories.Remove(categoryInDb);

            entities.SaveChanges();
            return Json(new
            {
                Status = "ok",
                Message = "Kayıt başarıyla silindi."
            });

        }



    }

}