using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Luolu.Interface;

namespace Luolu.Service
{
    public class TestService2: ServiceBase, ITest
    {
        public string Name()
        {
            return "TestSerice2服务";
        }

    }
}