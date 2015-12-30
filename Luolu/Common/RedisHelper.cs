using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Luolu.Models;
using ServiceStack.Redis.Support;

namespace Luolu.Common
{
    public class RedisHelper
    {
        private static RedisClient redis = new RedisClient("127.0.0.1", 6379);

        public static void Insert(string key, Student student)
        {
            redis.Set<Student>(key, student);
        }

        public static void Insertlist(string key, List<Student> list)
        {
            ObjectSerializer ser = new ObjectSerializer();
            redis.Set<byte[]>(key, ser.Serialize(list));
        }

        public static Student Get(string key)
        {
            //List<String> list = new List<String>();
            var list = redis.Get<Student>(key);
            return list;
        }

        public static List<Student> Getlist(string key)
        {
            ObjectSerializer ser = new ObjectSerializer();
            List<Student> list = new List<Student>();
            list = ser.Deserialize(redis.Get<byte[]>(key)) as List<Student>;
            return list; 
        }

        public static List<String> GetAllkeys()
        {
            var list = redis.GetAllKeys();
            return list;
        }
    }
}