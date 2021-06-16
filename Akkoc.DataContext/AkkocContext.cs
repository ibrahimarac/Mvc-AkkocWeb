using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Akkoc.DataContext
{
    public class AkkocContext : DbContext
    {
        public AkkocContext() : base("AkkocConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ChangeLog> Changes { get; set; }

        public DbSet<LogError> LogErrors { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Static> SiteStatics { get; set; }

        public DbSet<LoginUser> Logins { get; set; }

        public DbSet<UserRole> Roles { get; set; }

        public DbSet<Message> Messages { get; set; }

        public override int SaveChanges()
        {
            var changeInfo = ChangeTracker.Entries();
            LoginUser user = null;
            if (HttpContext.Current != null && HttpContext.Current.Session["user"] != null)
                user = HttpContext.Current.Session["user"] as LoginUser;
            foreach (var entry in changeInfo)
            {
                var log = new ChangeLog
                {
                    CreateDate = DateTime.Now,
                    LastupDate = DateTime.Now,
                    Status = entry.State,
                    LastupUser = (user != null) ? user.UserName : "admin",
                    RecordId = (entry.Entity is Base) ? (entry.Entity as Base).Id : 0,
                    EntityName = entry.Entity.GetType().Name
                };


                //Kaydedilen entity Base'den miras almıyorsa aşağıdaki
                //özelliklere zaten sahip değildir.
                if (entry.Entity is Base)
                {
                    //Eklenmeye veya güncellenmeye çalışılan kaydı Base türünden alalım.
                    var entity = entry.Entity as Base;
                    //Eğer kayıt ekleniyorsa
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreateUser = (user != null) ? user.UserName : "admin";
                        entity.LastupUser = (user != null) ? user.UserName : "admin";
                        entity.CreateDate = DateTime.Now;
                        entity.LastupDate = DateTime.Now;
                        entity.CreateUser = (user != null) ? user.UserName : "admin";
                        log.RecordId = entity.Id;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        //Veritabanı ilk defa oluşturuluyorsa işlem yapan kullanıcı admin olacak
                        if (user == null)
                            entity.LastupUser = "admin";
                        else
                            entity.LastupUser = user.UserName;
                        entity.LastupDate = DateTime.Now;
                    }
                }

                Changes.Add(log);

            }

            return base.SaveChanges();

        }

    }
}
