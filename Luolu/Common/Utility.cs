using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luolu.Common
{
    public class Utility
    {
        public static void writelog(string str)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("indexlog");
            log.Info(str);
        }
    }
}