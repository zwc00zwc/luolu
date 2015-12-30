using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Luolu.Interface;

namespace Luolu.Service
{
    public class TestService1 : ServiceBase, ITest
    {
        public string Name()
        {
            return "TestService1服务";
        }

    }
}