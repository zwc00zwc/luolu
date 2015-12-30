using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Messaging;

namespace Luolu.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/
        public ActionResult Index(int i=0)
        {
            int num = 0;
            num = plus(i);
            ViewBag.num = num;
            return View();
        }

        private int plus(int i)
        {
            if (i > 0)
            {
                if (i == 1)
                {
                    return 1;
                }
                if (i == 2)
                {
                    return 1;
                }
                else
                {
                    return plus(i - 1) + plus(i - 2);
                }
            }
            else
            {
                return 0;
            }
        }

        private void aaa()
        { 
        
        }

        public ActionResult Index1()
        {
            MessageQueue.Create(".\\Private$\\ImageQueue");
            MessageQueue messagequeue = new MessageQueue(".\\Private$\\ImageQueue");
            
            messagequeue.Send("aaaa");

            Message message = messagequeue.Receive();
            string aaa = message.Body.ToString();

            ViewBag.aaa = aaa;

            return View();
        }

        public ActionResult Index2(int m)
        {
            float sum = 0f;
            while (m > 0)
            {
                float temp = 1;
                for (int i = 1; i <= m; i++)
                {
                    temp = temp * i;
                }
                sum = sum + 1 / temp;
                m--;
            }
            ViewBag.sum = sum;
            return View();
        }

	}
}