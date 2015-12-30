using MyFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.BaseController
{
    public abstract class BaseController : Controller
    {
        public UserInfo CurrUserInfoP 
        {
            get
            {
                return HttpContext.User.Identity as UserInfo;
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectResult("Home/Index");
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.HttpContext.Response.Redirect("/Home/Index");
        }
    }
}
