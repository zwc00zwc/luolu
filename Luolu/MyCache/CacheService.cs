using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace Luolu.MyCache
{
    public class CacheService
    {
        private static object cacheLocker = new object();
        private static ICache cache = null;

        static CacheService()
        {
            Load();
        }

        private static void Load()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ICache>();
            IContainer container = null;

            try
            {
                container = builder.Build();
                cache = container.Resolve<ICache>();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (container != null)
                {
                    container.Dispose();
                }
            }
        }

        public static void Insert(string key, object data)
        {
            if (string.IsNullOrEmpty(key) || data == null)
            {
                return;
            }
            lock (cacheLocker)
            {
                cache.Insert(key, data);
            }
        }

        public static object Get(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return null;
            }
            return cache.Get(key);
        }
    }
}