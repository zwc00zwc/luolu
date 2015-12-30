using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Model
{
    public class UserInfo : IIdentity
    {
        public string AuthenticationType
        {
            get;
            set;
        }
        public bool IsAuthenticated
        {
            get { if (!string.IsNullOrEmpty(this.Id) && !string.IsNullOrEmpty(Name)) { return true; } else { return false; } }
        }
        public string Name
        {
            get;
            set;
        }
        public string Id
        {
            get;
            set;
        }
        public string role
        {
            get;
            set;
        }
        public string address
        {
            get;
            set;
        }
    }
}
