using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using AngularAuthentication.Adapters.Interfaces;
using AngularAuthentication.Adapters.Adapters;
using AngularAuthentication.Models;

//Used for User.Identity.GetUserid()

namespace AngularAuthentication.Controllers
{
    public class apiUserController : ApiController
    {
        IUserAdapter _adapter;
        public apiUserController()
        {
            _adapter = new UserAdapter();
        }
        public apiUserController(IUserAdapter a)
        {
            _adapter = a;
        }
        [Authorize]
        public IHttpActionResult Get()
        {
            string id = User.Identity.GetUserId();
            UserVM user = _adapter.GetUserInfo(id);
            return Ok(user);
        }
    }
}
