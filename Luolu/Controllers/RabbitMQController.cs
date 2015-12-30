using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Luolu.Controllers
{
    public class RabbitMQController : Controller
    {
        //
        // GET: /RabbitMQ/
        public ActionResult Index(string str)
        {
            string msg = "";
            try
            {
                ConnectionFactory factory = new ConnectionFactory();
                factory.HostName = "localhost";
                factory.UserName = "guest";
                factory.Password = "guest";
                using (IConnection conn = factory.CreateConnection())
                {
                    using (IModel channel = conn.CreateModel())
                    {
                        //在MQ上定义一个持久化队列，如果名称相同不会重复创建
                        channel.QueueDeclare("FirstQueue", false, false, false, null);
                        RequestMsg requestMsg = new RequestMsg();
                        byte[] bytes = Encoding.UTF8.GetBytes(str);

                        //设置消息持久化
                        IBasicProperties properties = channel.CreateBasicProperties();
                        properties.DeliveryMode = 1;
                        channel.BasicPublish("", "FirstQueue", properties, bytes);

                        //channel.BasicPublish("", "MyFirstQueue", null, bytes);

                        msg = "消息已发送";
                        
                    }
                }
            }
            catch (Exception e1)
            {
                msg = e1.ToString();
            }
            ViewBag.msg = msg;
            return View();
        }

        public ActionResult Index1() 
        {
            string resmsg = "";
            try
            {
                ConnectionFactory factory = new ConnectionFactory();
                factory.HostName = "localhost";
                factory.UserName = "guest";
                factory.Password = "guest";
                using (IConnection conn = factory.CreateConnection())
                {
                    using (IModel channel = conn.CreateModel())
                    {
                        //在MQ上定义一个持久化队列，如果名称相同不会重复创建
                        channel.QueueDeclare("FirstQueue", false, false, false, null);

                        //输入1，那如果接收一个消息，但是没有应答，则客户端不会收到下一个消息
                        channel.BasicQos(0, 1, false);

                        //在队列上定义一个消费者
                        QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                        //消费队列，并设置应答模式为程序主动应答
                        channel.BasicConsume("FirstQueue", false, consumer);
                        int num = 2;
                            //阻塞函数，获取队列中的消息
                            BasicDeliverEventArgs ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                            byte[] bytes = ea.Body;
                            string str = Encoding.UTF8.GetString(bytes);
                            RequestMsg msg = JsonConvert.DeserializeObject<RequestMsg>(str);
                            resmsg = msg.Name + "+" + msg.Code;
                            //回复确认
                            channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            ViewBag.msg = resmsg;
            return View();
        }

	}

    public class RequestMsg 
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}