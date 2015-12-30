using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class MvcHelpers
    {
        /// <summary>
        /// 测试用的mvc控件
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this System.Web.Mvc.HtmlHelper html)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<a ");
            sb.Append("href=\"javascript\"");
            sb.Append(">这是MvcHelper</a>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}