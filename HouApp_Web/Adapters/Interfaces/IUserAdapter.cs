using AngularAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularAuthentication.Adapters.Interfaces
{
    public interface IUserAdapter
    {
        UserVM GetUserInfo(string userId);
    }
}
