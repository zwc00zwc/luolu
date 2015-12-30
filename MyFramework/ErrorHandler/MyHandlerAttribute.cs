using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFramework.ErrorHandler
{
    public class MyHandlerAttribute : HandleErrorAttribute
    {
        public virtual void OnException(ExceptionContext filterContext)
        {
            string aaa = "进入异常了";
            string bbb = "进入异常了";
            string ccc = "进入异常了";
            base.OnException(filterContext);
        }
    }
}
