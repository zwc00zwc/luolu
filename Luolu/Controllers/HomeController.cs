using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Luolu.Common;
using System.Data.SqlClient;
using System.Data;
using Luolu.Models;
using Luolu.Interface;
using Luolu.Service;
using Luolu.Function;
using Luolu.MyCache;
using System.Web.Caching;
using System.Reflection;

namespace Luolu.Controllers
{
    public class HomeController : Controller
    {
        private string showstr = "show";
        public HomeController()
        { 
        
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //var salt = Guid.NewGuid().ToString();
            //Cache cache = new Cache();
            //string url = "";
            ////DataTable dt = SqlHelper.Read("select * from UrlList where U_Id=@Uid", new SqlParameter[] { new SqlParameter("@Uid", 13928) });
            //DataTable dt = SqlHelper.Read("select count(1) as 'count' from UrlList");
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        url = dt.Rows[i]["count"].ToString();
            //    }
            //}
            //ViewBag.url = url;
            return View();
        }

        public ActionResult Index1()
        {
            IFreightTemplate freBll = Instance<IFreightTemplate, FreightTemplateService>.Create;
            //IFreightTemplate freBll = new FreightTemplateService();
            FreightTemplateInfo fre = freBll.SearchByid("13676");
            //IProductInfo proBll = new ProductInfoService();
            //List<ProductInfo> list = proBll.SearchBypage(1, 20);
            //int num = proBll.Searchcount();
            return View(fre);
        }
        
        [ActionName("Index1")]
        public ActionResult Index3()
        {
            FunctionInfo info=new FunctionInfo();
            WebIoc.Register(test, showstr);
            ViewBag.show = showstr;
            return View();
        }

        public ActionResult Index4()
        {
            IProductAttributeInfo attBll = new ProductAttributeService();
            List<ProductAttributeInfo> attlist = attBll.SearchByproductid("320620");
            return View();
        }

        public ActionResult Index5()
        {
            List<Student> s = new List<Student>();
            List<Student> t = new List<Student>();
            Student dent = new Student() { Id = 4, Name = "赵六" };
            s.Add(new Student() { Id = 1, Name = "张三" });
            s.Add(new Student() { Id = 2, Name = "李四" });
            s.Add(new Student() { Id = 3, Name = "王五" });
            s.Add(dent);
            bool a = s.All(d => d.Name == "张三");
            return View();
        }

        private void test(string str)
        {
            showstr = "showshow";
        }

        public ActionResult Index6()
        {
            CacheService.Insert("test", "我是test");
            CacheService.Get("test");
            return View();
        }

        public ActionResult Index7()
        {
            Student student = new Student();
            PropertyInfo[] infos = student.GetType().GetProperties();
            List<string> liststr = new List<string>();

            foreach (PropertyInfo item in infos)
            {
                liststr.Add(item.Name);
            }
            ViewBag.str = liststr;
            return View();
        }
	}
}