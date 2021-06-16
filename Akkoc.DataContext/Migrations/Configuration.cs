namespace Akkoc.DataContext.Migrations
{
    using Domain.POCO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Akkoc.DataContext.AkkocContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Akkoc.DataContext.AkkocContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Akkoc.DataContext.AkkocContext context)
        {
            context.Categories.AddOrUpdate(c => c.Name,
               new Category { Name = "Kategori 1", Description = "Açıklama 1", Order = 1 },
               new Category { Name = "Kategori 2", Description = "Açıklama 2", Order = 2 },
               new Category { Name = "Kategori 3", Description = "Açıklama 3", Order = 3 }
            );

            context.Roles.AddOrUpdate(r => r.RoleName,
                new UserRole { RoleName = "user", Description = "Standart kullanıcı rolü." },
                new UserRole { RoleName = "admin", Description = "En yetkili kullanıcı rolü." }
            );

            //Rolleri ve kategorileri ekle
            context.SaveChanges();

            context.Logins.AddOrUpdate(u => u.UserName,
                 new LoginUser { UserName = "user", Password = "123456", RoleId = 1, Name = "UserName", Surname = "UserSurname" },
                new LoginUser { UserName = "admin", Password = "123456", RoleId = 2, Name = "AdminName", Surname = "AdminSurname" }
            );

            if (context.SiteStatics.Count() == 0)
            {
                context.SiteStatics.Add(
                    new Static
                    {
                        AboutDescription = "About Description",
                        AboutTitle = "About Title",
                        Address = "Adres",
                        Copyrigth = "Her hakkı saklıdır",
                        CreateUser = "admin",
                        Email1 = "email1@gmail.com",
                        Email2 = "email2@gmail.com",
                        FacebookUrl = "www.facebook.com/akkoc",
                        Instagram = "Akkoc",
                        InstagramUrl = "www.instagram.com/akkoc",
                        CreateDate = DateTime.Now,
                        LastupUser = "admin",
                        Location = "39,32",
                        LogoImage = "/Content/images/global/star.png",
                        MailPassword = "password",
                        MailUserName = "username",
                        LogoTitle = "Logo Title",
                        PinterestUrl = "www.pniterest.com/akkoc",
                        SiteMail = "akkoc@gmail.com",
                        Tel1 = "(555) 555 55 55",
                        Tel2 = "(555) 555 55 55",
                        VideoFile = "/Content/video/video1.mp4",
                        LastupDate=DateTime.Now,
                        IsActive=true
                    });
            }

            context.SaveChanges();
        }
    }
}
