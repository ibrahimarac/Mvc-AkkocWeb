using Akkoc.DataContext;
using Akkoc.Domain.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akkoc.Utils;

namespace Akkoc.Web.Areas.Admin.Controllers
{
    [CheckUser(Roles = "admin,user")]
    public class SiteStaticController:BaseController
    {
        [HttpGet]
        public ActionResult Edit()
        {
            ViewBag.Title = "Site Sabitleri";
            AkkocContext entities = new AkkocContext();
            var statics = entities.SiteStatics.FirstOrDefault();
            StaticWithVideoUpload model = new StaticWithVideoUpload();

            if (statics != null)
            {
                model.StaticModel = statics;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StaticWithVideoUpload model)
        {
            ViewBag.Title = "Site Sabitleri";

            //1. senaryo bu bilgileri ilk defa kaydediliyor
            //2. senaryo daha önce kaydedilen bilgiler güncelleniyor

            AkkocContext entities = new AkkocContext();
            var statics = entities.SiteStatics.FirstOrDefault();
            if(statics==null)
            {
                //insert

                //video dosyası varsa kaydet
                if(model.PostedFile!=null)
                {
                    //video dosyasının ismini oluşturup kaydettim
                    string fileName = model.PostedFile.GenerateFileName();
                    string filePath = Server.MapPath("~/Content/video/" + fileName);
                    model.PostedFile.SaveAs(filePath);
                    model.StaticModel.VideoFile = fileName;
                    
                }

                //video dosyası varsa kaydet
                if (model.LogoFile != null)
                {
                    //video dosyasının ismini oluşturup kaydettim
                    string fileName = model.LogoFile.GenerateFileName();
                    string filePath = Server.MapPath("~/Content/images/global/" + fileName);
                    var croppedImage=model.LogoFile.CropImage(Request.Form);
                    croppedImage.Save(filePath);
                    model.StaticModel.LogoImage = fileName;

                }

                //şimdi veritabanına bilgileri kaydedelim.
                entities.SiteStatics.Add(model.StaticModel);               
            }
            else
            {
                //update
                if(model.PostedFile!=null)
                {
                    //video dosyasının ismini oluşturup kaydettim
                    string fileName = model.PostedFile.GenerateFileName();
                    string filePath = Server.MapPath("~/Content/video/" + fileName);
                    model.PostedFile.SaveAs(filePath);
                    //önce eski video dosyasını silelim
                    var oldVideoFilePath = Server.MapPath("~/Content/video/" + statics.VideoFile);
                    if (System.IO.File.Exists(oldVideoFilePath))
                        System.IO.File.Delete(oldVideoFilePath);
                    //yeni dosyanın adını model'e ekleyelim.
                    statics.VideoFile = fileName;
                }

                if (model.LogoFile != null)
                {
                    //video dosyasının ismini oluşturup kaydettim
                    string fileName = model.LogoFile.GenerateFileName();
                    string filePath = Server.MapPath("~/Content/images/global/" + fileName);
                    var croppedImage = model.LogoFile.CropImage(Request.Form);
                    croppedImage.Save(filePath);
                    //şimdi eski logo resmini silelim.
                    var oldLogoFilePath = Server.MapPath("~/Content/images/global/" + statics.LogoImage);
                    if (System.IO.File.Exists(oldLogoFilePath))
                        System.IO.File.Delete(oldLogoFilePath);
                    //yeni dosyanın adını model'e ekleyelim.
                    statics.LogoImage = fileName;
                }

                //şimdi logo dosyasına ait işlemleri halledelim.

                statics.AboutDescription = model.StaticModel.AboutDescription;
                statics.AboutTitle = model.StaticModel.AboutTitle;
                statics.Address = model.StaticModel.Address;
                statics.Copyrigth = model.StaticModel.Copyrigth;
                statics.Email1 = model.StaticModel.Email1;
                statics.Email2 = model.StaticModel.Email2;
                statics.Location = model.StaticModel.Location;
                statics.SiteMail = model.StaticModel.SiteMail;
                statics.MailUserName = model.StaticModel.MailUserName;
                statics.MailPassword = model.StaticModel.MailPassword;
                statics.FacebookUrl = model.StaticModel.FacebookUrl;
                statics.Instagram = model.StaticModel.Instagram;
                statics.InstagramUrl = model.StaticModel.InstagramUrl;
                statics.IsActive = model.StaticModel.IsActive;
                statics.LastupDate = DateTime.Now;
                statics.LastupUser = "user-1";
                statics.PinterestUrl = model.StaticModel.PinterestUrl;
                statics.Tel1 = model.StaticModel.Tel1;
                statics.Tel2 = model.StaticModel.Tel2;
                statics.LogoTitle = model.StaticModel.LogoTitle;
            }
            entities.SaveChanges();
            TempData["success"] = "Kayıt başarıyla tamamlandı.";
            return View(model);
        }
    }
}