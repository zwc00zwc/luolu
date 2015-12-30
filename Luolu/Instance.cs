using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Luolu.Interface;
using Autofac;
using Autofac.Configuration;
using Luolu.Service;

namespace Luolu
{
    public class Instance<T1,T2> where T1:IService where T2:ServiceBase
    {
        public static T1 Create 
        {
            get
            {
                var builder = new ContainerBuilder();
                T1 t;
                IContainer container = null;
                builder.RegisterType<T2>().As<T1>();
                container = builder.Build();
                t = container.Resolve<T1>();
                return t;
            }
        }
    }
}