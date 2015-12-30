using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Luolu.Controllers
{
    public class XmlController : Controller
    {
        private static string Getpath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config", "XMLFile1.xml"); }
        }
        //
        // GET: /Xml/
        public ActionResult Index()
        {
            string aa = "";
            XmlDocument doc = new XmlDocument();
            using (XmlReader xr = XmlReader.Create(Getpath))
            {
                doc.Load(xr);
            }
            XmlNodeList sl = doc.GetElementsByTagName("SuccNum");
            aa = sl[0].InnerText;
            ViewBag.aa = aa;
            return View();
        }

        public ActionResult Index2()
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", null), new XElement("SuccNum", 50));
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            using (XmlWriter xw = XmlWriter.Create(Getpath, setting))
            {
                doc.WriteTo(xw);
            }
            return View();
        }
	}
}