using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luolu.Common
{
    public class Test
    {
        private static Test test = null;
        private static object lock_f = null;

        public Test()
        {
            fangfa(false);
        }

        public static Test Instance()
        {
            if (test == null)
            {
                test = new Test();
            }
            return test;
        }

        public void fangfa(bool isfirst)
        {
            if (isfirst)
            {

            }
            else
            { 
            
            }
        }
    }
}