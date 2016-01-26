using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using ZF.XML;
using ZF.Log;
using ConfigFramework;
using ConfigFramework.ConfigManger;

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

        public ActionResult CreateXML()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Person.xml");
            string error = "";
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
                {
                    List<Person> list = new List<Person>();
                    list.Add(new Person() { Id = 1, Name = "张三", Age = "20" });
                    list.Add(new Person() { Id = 2, Name = "李四", Age = "20" });
                    list.Add(new Person() { Id = 3, Name = "王五", Age = "20" });

                    PersonSet ps = new PersonSet();
                    ps.PersonList = list;

                    XMLHelper.serializeXmlFile(fs, typeof(PersonSet), ps);
                    LogHelper.WriteInfo("成功插入xml");
                    error = "成功";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                error = "失败";
            }
            ViewBag.error = error;
            return View();
        }

        public ActionResult ReadXML()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Person.xml");
            PersonSet ps = new PersonSet();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                ps = XMLHelper.DeserializeXmlFile(fs, typeof(PersonSet)) as PersonSet;
            }
            return View(ps);
        }

        public ActionResult Index4()
        {
            string aaa = ConfigMangerHelper.Get<string>("Luolu");
            //Common.Test.Instance().fangfa(true);
            return View();
        }
	}

    public class PersonSet
    {
        public List<Person> PersonList { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
}