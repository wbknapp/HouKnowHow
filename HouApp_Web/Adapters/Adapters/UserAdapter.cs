using AngularAuthentication.Adapters.Interfaces;
using AngularAuthentication.Models;
using HouApp_Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularAuthentication.Adapters.Adapters
{
    public class UserAdapter: IUserAdapter
    {
        public UserVM GetUserInfo(string userId)
        {
            UserVM user;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                user = db.Users.Where(x => x.Id == userId).Select(x => new UserVM()
                {
                    Username = x.UserName,
                    Email = x.Email
                }).FirstOrDefault();
            }
            return user;
        }
    }
}