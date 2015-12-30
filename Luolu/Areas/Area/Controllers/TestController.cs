using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luolu.Areas.Area.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Area/Test/
        public ActionResult Index()
        {
            ViewBag.a = "test";
            return View();
        }
	}
}