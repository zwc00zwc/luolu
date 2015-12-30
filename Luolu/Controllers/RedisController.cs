using Luolu.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Luolu.Common;
using MyFramework.BaseController;

namespace Luolu.Controllers
{
    public class RedisController : BaseController
    {
        
        //
        // GET: /Redis/
        public ActionResult Index()
        {
            Student student = new Student() { Id = 1, Name = "zhangsan" };
            RedisHelper.Insert("student", student);

            RedisHelper.Insertlist("list", new List<Student>() { new Student() { Id = 1, Name = "zhangsan" }, new Student() { Id = 3, Name = "wangwu" } });
            return View();
        }

        public ActionResult Index1()
        {
            Student list = RedisHelper.Get("student");

            var stus = RedisHelper.Getlist("list");
            ViewBag.list = list;
            return View();
        }

        public ActionResult Index2()
        {
            List<String> list = RedisHelper.GetAllkeys();
            return View();
        }
	}
}