using HouApp_Web.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace HouApp_Web.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool roles = true, bool users = true)
        {
            if (roles) SeedRoles(db);
            if (users) SeedUsers(db);
        }

        private static void SeedRoles(ApplicationDbContext db)
        {
            var manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!manager.RoleExists("User"))
            {
                manager.Create(new IdentityRole() { Name = "User" });
            }
            if (!manager.RoleExists("Admin"))
            {
                manager.Create(new IdentityRole() { Name = "Admin" });
            }
        }

        private static void SeedUsers(ApplicationDbContext db)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!db.Users.Any(x => x.UserName == "user"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "user",
                    Email = "test@test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }

            if (!db.Users.Any(x => x.UserName == "Admin"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "Admin",
                    Email = "admin@test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }

            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //29.759553, -95.356232
            //29.746997, -95.370029
            //29.731756, -95.351425
            //29.726670, -95.362744
            //29.727788, -95.380425
            db.ImageCollabs.AddOrUpdate(
                i => i.ImageCollabId,
                        new ImageCollab() { ImageCollabId = 1, Address="611 Walker St 77002", Description="nice mural", LocLat = "29.759553", LocLong = "-95.356232", PostType = "art", UrlString = "https://02varvara.files.wordpress.com/2012/06/00b-street-art-mexico-city-mx-05-12.jpg" },
                        new ImageCollab() { ImageCollabId = 2, Address = "3010 Briarpark Dr, Suite 500", Description = "groovy mural", LocLat = "29.746997", LocLong = "-95.370029", PostType = "art", UrlString = "https://02varvara.files.wordpress.com/2012/06/00a-street-art-naples-it-05-12.jpg?w=1024" },
                        new ImageCollab() { ImageCollabId = 3, Address = "3201 Allen Parkway, Suite 250", Description = "nice mural", LocLat = "29.731756", LocLong = "-95.351425", PostType = "art", UrlString = "http://media.creativebloq.futurecdn.net/sites/creativebloq.com/files/images/2014/01/yes2.jpg" },
                        new ImageCollab() { ImageCollabId = 4, Address = "9797 westheimer", Description = "flattend my tires", LocLat = "29.726670", LocLong = "-95.362744", PostType = "pothole", UrlString = "http://www.einsteinsoilery.com/wp-content/uploads/2013/04/pothole-damage-boise-merididan-garden-city-idaho-oil-changes-e1367265778840.jpg" },
                        new ImageCollab() { ImageCollabId = 4, Address="1953 Montrose Blvd", Description="hurts my back", LocLat = "29.727788", LocLong = "-95.380425", PostType = "pothole", UrlString = "http://21onuv2o3diqcdqccz3o9c12iv.wpengine.netdna-cdn.com/wp-content/uploads/2009/04/china_pothole-[gadling-bumper].jpg" }
                    );


        }
    }
}
