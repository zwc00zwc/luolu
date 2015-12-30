using Luolu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luolu.MyCache
{
    public interface ICache : IService
    {
        void Insert(string key, object data);

        object Get(string key);
    }
}