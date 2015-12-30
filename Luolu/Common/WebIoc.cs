using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Luolu.Function;

namespace Luolu.Common
{
    public class WebIoc
    {
        public static void Register(Action<string> fun,string str)
        {
            fun(str);
        }
    }
}