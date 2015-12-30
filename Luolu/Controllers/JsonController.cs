using Luolu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luolu.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            Student s=new Student();
            List<Student> l1 = new List<Student>();
            l1.Add(new Student() { Id = 1, Name = "张三" });
            l1.Add(new Student() { Id = 2, Name = "李四" });
            List<Student> l2 = new List<Student>();
            s.Id = 1;
            s.Name = "张三";
            string b = JsonConvert.SerializeObject(s);
            string a = JsonConvert.SerializeObject(l1); ;
            l2 = JsonConvert.DeserializeObject<List<Student>>(a);
            return View();
        }
    }
}