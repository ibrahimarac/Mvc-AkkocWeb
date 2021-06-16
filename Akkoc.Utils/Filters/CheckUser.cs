using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Akkoc.Utils
{
    public class CheckUser:AuthorizeAttribute
    {
        bool allowed;

        //Kullanıcının yetki durumunu kontrol etmek için kullanılacak
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            allowed = false;

            //izin verilen roller alınıyor.
            var roles = Roles.Split(',');
            //oturum açmış kullanıcı elde ediliyor.
            var user = filterContext.HttpContext.Session["user"] as LoginUser;
            //Çalışan action için AllowAnonymous attribute uygulanmış mı?
            var allowAnonymous = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();

            //Çalışan Action'a AllowAnonymous ettribute uygulanmamış.
            if (!allowAnonymous)
            {
                if(user!=null)
                {
                    //Yetkilendirme role ait bir kısıtlamaya sahip değil
                    //oturum açan herkes yetkili kabul edilebilir.
                    if (string.IsNullOrEmpty(Roles))
                        allowed = true;
                    else
                    {
                        if (roles.Contains(user.Role.RoleName))
                            allowed = true;
                    }
                }
            }
            else
            {
                //Çalışan Action'a AllowAnonymous ettribute uygulanmış.
                //Her türlü kontrolden muaftır.
                allowed = true;
            }

            base.OnAuthorization(filterContext);
        }
        
        //Kullanıcının yetkisiz olduğu bir sayfaya erişmesi durumunda çalışacak
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Buraya düşen kullanıcı ya oturum açmamıştır yada
            //talep ettiği sayfayı görmeye yetkili değildir.
            filterContext.HttpContext.Response.Clear();
            var url = filterContext.HttpContext.Request.Url.AbsolutePath;
            //filterContext.Result = new RedirectResult("/Admin/Account/Login?ReturnUrl=" + url);
            filterContext.HttpContext.Response.Redirect("/Admin/Account/Login?ReturnUrl=" + url);
        }
        
        //true döndürürse kullanıcı yetkili,false döndürürse yetkisiz.
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return allowed;
        }
    }
}
