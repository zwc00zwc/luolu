using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luolu.Interface
{
    public interface ITest : IService
    {
        string Name();
    }
}