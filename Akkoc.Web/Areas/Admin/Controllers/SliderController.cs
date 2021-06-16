using Akkoc.Domain.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akkoc.Utils;
using Akkoc.DataContext;

namespace Akkoc.Web.Areas.Admin.Controllers
{
    [CheckUser(Roles = "admin,user")]
    public class SliderController : BaseController
    {
        public ActionResult Create()
        {
            ViewBag.Title = "Slayt Oluştur";
            return View();
        }

        [HttpPost]
        public ActionResult Create(SliderWithImage model)
        {
            //Önce resmi kaydetmeye çalışalım

            //Resmi kırpıyoruz
            var croppedImage= model.SliderImage.CropImage(Request.Form);
            //Resim dosyası için yeni bir isim üretiyoruz
            var fileName = model.SliderImage.GenerateFileName();
            //Resim dosyasını kaydedeceğimiz fiziksel yolu hesaplıyoruz.
            var filePath = Server.MapPath("~/Content/images/slider/"+fileName);
            croppedImage.Save(filePath);

            //Slider bilgilerini kaydedelim.
            var entities = new AkkocContext();
            entities.Sliders.Add(model.Slider);
            //kaydedilen resmin adını slider'ın resmine yükleyelim.
            model.Slider.SliderImage = fileName;
            entities.SaveChanges();

            TempData["success"] = "Slayt başarıyla kaydedildi.";
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            ViewBag.Title = "Kayıtlı Slaytlar";
            var entities = new AkkocContext();
            var sliders = entities.Sliders.ToList();
            return View(sliders);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var entities = new AkkocContext();
            var sliderInDb = entities.Sliders.SingleOrDefault(s => s.Id == id);
            if(sliderInDb==null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen kriterlere uygun bir slayt bulunamadı."
                });
            }
            //veritabanında gerçekten böyle bir slayt var
            //önce slider'a ait resmi silelim
            var fileName = sliderInDb.SliderImage;
            var filePath = Server.MapPath("~/Content/images/slider/" + fileName);

            //şimdi slider'a ait bilgileri veritabanından silelim
            entities.Sliders.Remove(sliderInDb);
            entities.SaveChanges();

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            return Json(new
            {
                Status = "ok",
                Message = "Kayıt başarıyla silindi."
            });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Slayt Güncelleme Ekranı";

            var entities = new AkkocContext();
            var sliderInDb = entities.Sliders.SingleOrDefault(s => s.Id == id);
            if(sliderInDb==null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir kayıt bulunamadı.";
                return RedirectToAction("List");
            }
            var sliderWithImage = new SliderWithImage();
            sliderWithImage.Slider = sliderInDb;
            return View(sliderWithImage);
        }

        [HttpPost]
        public ActionResult Edit(SliderWithImage model)
        {
            var entities = new AkkocContext();
            //veritabanından, güncellenmeye çalışılan slider'a ait bilgileri getir
            var sliderInDb = entities.Sliders.SingleOrDefault(s => s.Id == model.Slider.Id);
            //veritabanında bulamadıysam hata mesajı ile View'e dön
            if(sliderInDb==null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir slayt bulunamadı.";
                return View(model);
            }
            sliderInDb.IsActive = model.Slider.IsActive;
            sliderInDb.Order = model.Slider.Order;
            sliderInDb.Title = model.Slider.Title;
            sliderInDb.Email = model.Slider.Email;
            sliderInDb.Description = model.Slider.Description;
            sliderInDb.Detail = model.Slider.Detail;

            //kullanıcı bu slider için farklı bir resim seçmiş
            if(model.SliderImage!=null)
            {
                //eski resmi klasörden kaldır
                var filePath = sliderInDb.SliderImage.GetPhysicalPath("slider");
                if(System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                //yeni resmi kaydet
                var croppedImage=model.SliderImage.CropImage(Request.Form);
                var fileName = model.SliderImage.GenerateFileName();
                filePath = fileName.GetPhysicalPath("slider");
                croppedImage.Save(filePath);
                //yeni yüklenen resmin adını veritabanına da yazalım.
                sliderInDb.SliderImage = fileName;
            }
            entities.SaveChanges();
            TempData["success"] = "Slider başarıyla güncellendi.";
            return RedirectToAction("List");
        }

    }
}