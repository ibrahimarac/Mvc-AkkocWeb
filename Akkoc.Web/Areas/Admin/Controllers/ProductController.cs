using Akkoc.DataContext;
using Akkoc.Domain.VM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akkoc.Utils;
using Akkoc.Domain.POCO;
using System.Data.Entity;

namespace Akkoc.Web.Areas.Admin.Controllers
{
    [CheckUser(Roles = "admin,user")]
    public class ProductController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Katagorileri açılır kutu için hazırla
            var entities = new AkkocContext();
            var categories = entities.Categories
                .Where(c => c.IsActive)
                .OrderBy(c => c.Id)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            TempData["categories"] = categories;

            base.OnActionExecuting(filterContext);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Ürün Ekle";
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductWithImage product)
        {
            var productModel = product.ProductModel;
            var orgImage = product.ProductImage;

            //resim dosyası için üretilen ismi elde edelim.
            string fileName = orgImage.GenerateFileName();
            

            //Orjinal resmi kırpma alanına ait bilgilerle kırpan metod
            Image resultImage = orgImage.CropImage(Request.Form);

            //Ürün resmini sunucuya kaydedelim.
            resultImage.Save(Server.MapPath("~/Content/images/product/full/" + fileName));
            var thumbImage = resultImage.FixedSize(570, 400);
            thumbImage.Save(Server.MapPath("~/Content/images/product/thumb/" + fileName));
            TempData["success"] = "Ürün başarıyla eklendi.";

            //Ürün bilgilerini kaydedelim
            AkkocContext entities = new AkkocContext();
            //ürün bilgilerinde yer alan dosya ismini ayarlayalım.
            productModel.ProductImage = fileName;
            productModel.ProductThumbImage = fileName;
            entities.Products.Add(productModel);
            //ürünü veritabanına kaydedelim.
            entities.SaveChanges();

            return RedirectToAction("List");
        }


        public ActionResult List()
        {
            var category = new Category();
            ViewBag.Title = "Kayıtlı Ürünler";
            var entities = new AkkocContext();
            var products = entities.Products.Include("Category").ToList();
            return View(products);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            AkkocContext entities = new AkkocContext();
            var productInDb = entities.Products.SingleOrDefault(c => c.Id == id);
            if (productInDb == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen id değerine sahip bir ürün bulunamadı."
                });
            }
            //silinen ürüne ait resim dosyasının adı
            var imageUrl = productInDb.ProductImage;

            //Ürünü siliyorum
            entities.Products.Remove(productInDb);
            entities.SaveChanges();

            //Ürüne ait kayıtlı resmi de silelim.
            string filePath = Server.MapPath("~/Content/images/product/full/" + imageUrl);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            //Ürüne ait thumbnail image'i silelim
            string thumbPath= Server.MapPath("~/Content/images/product/thumb/" + imageUrl);
            if (System.IO.File.Exists(thumbPath))
                System.IO.File.Delete(thumbPath);

            return Json(new
            {
                Status = "ok",
                Message = "Ürün başarıyla silindi."
            });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Ürünü Güncelle";
            var entities = new AkkocContext();
            var productInDb = entities.Products.SingleOrDefault(p => p.Id == id);
            if (productInDb == null)
            {
                TempData["error"] = "Belirtilen kriterlere sahip ürün bulunamadı";
                return RedirectToAction("List");
            }
            ProductWithImage productImageModel = new ProductWithImage();
            productImageModel.ProductModel = productInDb;
            return View(productImageModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductWithImage model)
        {
            var entities = new AkkocContext();

            //Veritabanında kayıtlı olan ürün bilgisini çekelim
            var productInDb = entities.Products.SingleOrDefault(p => p.Id == model.ProductModel.Id);
            if (productInDb == null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir ürün bulunamadı.";
                return View(model);
            }
            productInDb.IsActive = model.ProductModel.IsActive;
            productInDb.LastupDate = DateTime.Now;
            productInDb.Name = model.ProductModel.Name;
            productInDb.Order = model.ProductModel.Order;
            productInDb.Price = model.ProductModel.Price;
            productInDb.CategoryId = model.ProductModel.CategoryId;
            productInDb.Description = model.ProductModel.Description;

            //kullanıcı ürüne ait mevcut resmi değiştirmiş
            if (model.ProductImage != null)
            {
                //ürüne ait kayıtlı resim değiştirilecek
                //Orjinal resmi kırpma alanına ait bilgilerle kırpan metod
                Image resultImage = model.ProductImage.CropImage(Request.Form);

                //resim dosyası için üretilen ismi elde edelim.
                string fileName = model.ProductImage.GenerateFileName();

                //Ürün resmini sunucuya kaydedelim.
                resultImage.Save(Server.MapPath("~/Content/images/product/full/" + fileName));
                //Ürüne ait thumbnail image kaydediliyor
                var thumbImage = resultImage.FixedSize(570, 400);
                thumbImage.Save(Server.MapPath("~/Content/images/product/thumb/" + fileName));

                //eski resmi silelim
                if (System.IO.File.Exists(Server.MapPath("~/Content/images/product/full/" + productInDb.ProductImage)))
                    System.IO.File.Delete(Server.MapPath("~/Content/images/product/full/" + productInDb.ProductImage));
                //eski thumb image'i silelim.
                if (System.IO.File.Exists(Server.MapPath("~/Content/images/product/thumb/" + productInDb.ProductImage)))
                    System.IO.File.Delete(Server.MapPath("~/Content/images/product/thumb/" + productInDb.ProductImage));

                //Yeni resim adını ürüne kaydedelim.
                productInDb.ProductImage = fileName;
                //thumbnail image'in adını ürüne kaydedelim
                productInDb.ProductThumbImage = fileName;
            }

            entities.SaveChanges();
            TempData["success"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("List");
        }

    }
}