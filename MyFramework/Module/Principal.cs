using MyFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Module
{
    public class Principal : IPrincipal
    {
        private UserInfo userinfo;
        public Principal(UserInfo user)
        {
            if (user != null)
            {
                this.userinfo = user;
            }
        }

        public IIdentity Identity 
        {
            get { return userinfo; }
        }

        public bool IsInRole(string role)
        {
            return false;
        }

    }
}
