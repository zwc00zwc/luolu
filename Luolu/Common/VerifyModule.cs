using MyFramework.Model;
using MyFramework.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luolu.Common
{
    public class VerifyModule : IHttpModule
    {
        public void Dispose()
        {

        }
        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
        }

        void context_AcquireRequestState(object sender, EventArgs args)
        {
            //处理方法往
            HttpContext.Current.User = new Principal(new UserInfo());
        }
    }
}