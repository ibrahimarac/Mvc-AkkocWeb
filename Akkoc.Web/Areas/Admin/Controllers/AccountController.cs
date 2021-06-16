using Akkoc.DataContext;
using Akkoc.Domain.POCO;
using Akkoc.Domain.VM;
using Akkoc.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akkoc.Web.Areas.Admin.Controllers
{
    [CheckUser]
    public class AccountController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var entities = new AkkocContext();
            TempData["roles"] = entities.Roles.Select(r => new SelectListItem
            {
                Text = r.RoleName,
                Value = r.Id.ToString()
            }).ToList();
            base.OnActionExecuting(filterContext);
        }
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.Title = "Oturum Açın";
            AccountModel model = new AccountModel();
            if(Request.Cookies["username"]!=null)
            {
                model.UserName = Request.Cookies["username"].Value;
                model.RememberMe = true;
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(AccountModel model)
        {
            ViewBag.Title = "Oturum Açın";
            var entities = new AkkocContext();
            var loginInDb = entities.Logins.Include("Role").SingleOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
            //Girilen bilgilerle eşleşen bir kullanıcı yoksa
            if (loginInDb == null)
            {
                TempData["error"] = "Kullanıcı adı veya parola geçersiz.";
                return View(model);
            }
            //oturum açtı. oturum bilgilerini saklayıp kullanıcıyı uygun bir sayfaya gönderelim.
            Session["user"] = loginInDb;
            //lastlogindate ayarlanıyor
            loginInDb.LastLoginDate = DateTime.Now;
            entities.SaveChanges();
            //Beni Hatırla işaretlenmiş mi?
            if(model.RememberMe)
            {
                HttpCookie cookie = new HttpCookie("username", model.UserName);
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
            }
            else
            {
                //beni hatırla işaretlenmemiş ve daha önceden kalan bir çerez varsa
                if (Request.Cookies["username"] != null)
                    Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Request.QueryString["ReturnUrl"] != null)
                return Redirect(Request.QueryString["ReturnUrl"]);

            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

        [CheckUser(Roles ="admin")]
        public ActionResult CreateUser()
        {
            ViewBag.Title = "Kullanıcı Oluştur";
            return View();
        }

        [HttpPost]
        [CheckUser(Roles = "admin")]
        public ActionResult CreateUser(LoginWithImage model)
        {
            ViewBag.Title = "Kullanıcı Oluştur";
            if (model.PostedFile!=null)
            {
                //gönderilen resim kaydediliyor.
                var fileName= model.PostedFile.GenerateFileName();
                var filePath = Server.MapPath("~/Areas/Admin/Content/images/users/" + fileName);
                var croppedImage=model.PostedFile.CropImage(Request.Form);
                croppedImage.Save(filePath);
                model.LoginModel.UserImage = fileName;
            }
            else
            {
                TempData["error"] = "Kullanıcı resmi seçilmelidir.";
                return View(model);
            }
            var entities = new AkkocContext();
            entities.Logins.Add(model.LoginModel);
            entities.SaveChanges();
            TempData["success"] = "Kullanıcı başarıyla eklendi.";
            return RedirectToAction("ListUsers");
        }

        [CheckUser(Roles = "admin")]
        public ActionResult ListUsers()
        {
            ViewBag.Title = "Kayıtlı Kullanıcılar";
            var entities = new AkkocContext();
            var users = entities.Logins.Include("Role").ToList();
            return View(users);
        }

        [HttpPost]
        [CheckUser(Roles = "admin")]
        public ActionResult DeleteUser(int id)
        {
            var entities = new AkkocContext();
            var userInDb = entities.Logins.SingleOrDefault(u => u.Id == id);
            if(userInDb==null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen kriterlere uygun bir kullanıcı bulunamadı."
                });
            }
            //kullanıcı var. Resmini silelim.
            var fileName = userInDb.UserImage;
            var filePath= Server.MapPath("~/Areas/Admin/Content/images/users/" + fileName);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            //şimdi veritabanında yer alan kaydı silelim.
            entities.Logins.Remove(userInDb);
            entities.SaveChanges();
            return Json(new
            {
                Status="ok",
                Message="Kullanıcı başarıyla silindi."
            });
        }

        [CheckUser(Roles = "admin")]
        public ActionResult EditUser(int id)
        {
            ViewBag.Title = "Kullanıcı Güncelle";
            var entities = new AkkocContext();
            var userInDb = entities.Logins.SingleOrDefault(u => u.Id == id);
            if(userInDb==null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir kullanıcı bulunamadı.";
                return RedirectToAction("ListUsers");
            }
            //kullanıcı bulundu. Güncellemek üzere View'e gönder
            LoginWithImage model = new LoginWithImage();
            model.LoginModel = userInDb;
            return View(model);
        }

        [HttpPost]
        [CheckUser(Roles = "admin")]
        public ActionResult EditUser(LoginWithImage model)
        {
            ViewBag.Title = "Kullanıcı Güncelle";
            var entities = new AkkocContext();
            var userInDb = entities.Logins.SingleOrDefault(u => u.Id == model.LoginModel.Id);

            if(model.PostedFile!=null)
            {
                var fileName = userInDb.UserImage;
                var filePath= Server.MapPath("~/Areas/Admin/Content/images/users/" + fileName);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
                //yeni resmi yükleyelim.
                var newFileName=model.PostedFile.GenerateFileName();
                var newCroppedImage = model.PostedFile.CropImage(Request.Form);
                var newFilePath= Server.MapPath("~/Areas/Admin/Content/images/users/" + newFileName);
                newCroppedImage.Save(newFilePath);
                userInDb.UserImage = newFileName;
            }
            userInDb.IsActive = model.LoginModel.IsActive;
            userInDb.Name = model.LoginModel.Name;
            userInDb.Surname = model.LoginModel.Surname;
            entities.SaveChanges();
            return RedirectToAction("ListUsers");
        }

        [CheckUser(Roles = "admin")]
        public ActionResult CreateRole()
        {
            ViewBag.Title = "Rol Ekle";
            return View();
        }

        [HttpPost]
        [CheckUser(Roles = "admin")]
        public ActionResult CreateRole(UserRole role)
        {
            ViewBag.Title = "Rol Ekle";
            var entities = new AkkocContext();
            entities.Roles.Add(role);
            entities.SaveChanges();
            TempData["success"] = "Rol başarıyla eklendi.";
            return RedirectToAction("ListRoles");
        }

        [CheckUser(Roles = "admin")]
        public ActionResult ListRoles()
        {
            ViewBag.Title = "Rolleri Düzenle";
            var entities = new AkkocContext();
            return View(entities.Roles.ToList());
        }

        [HttpPost]
        [CheckUser(Roles = "admin")]
        public ActionResult DeleteRole(int id)
        {
            var entities = new AkkocContext();
            var roleInDb = entities.Roles.SingleOrDefault(r => r.Id == id);
            if(roleInDb==null)
            {
                return Json(new
                {
                    Status="error",
                    Message="Belirtilen kriterlere uygun bir rol bulunamadı."
                });
            }
            entities.Roles.Remove(roleInDb);
            entities.SaveChanges();
            return Json(new
            {
                Status = "ok",
                Message = "Rol başarıyla silindi."
            });
        }

        [CheckUser(Roles = "admin")]
        public ActionResult EditRole(int id)
        {
            ViewBag.Title = "Rol Bilgilerini Güncelle";
            var entities = new AkkocContext();
            var roleInDb= entities.Roles.SingleOrDefault(r => r.Id == id);
            if(roleInDb==null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir rol bulunamadı.";
                return RedirectToAction("ListRoles");
            }
            return View(roleInDb);
        }

        [HttpPost]
        [CheckUser(Roles = "admin")]
        public ActionResult EditRole(UserRole role)
        {
            ViewBag.Title = "Rol Bilgilerini Güncelle";
            var entities = new AkkocContext();
            if(entities.Entry(role).State==System.Data.Entity.EntityState.Detached)
            {
                entities.Roles.Attach(role);
            }
            entities.Entry(role).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
            TempData["success"] = "Rol başarıyla güncellendi.";
            return RedirectToAction("ListRoles");
        }

    }
}