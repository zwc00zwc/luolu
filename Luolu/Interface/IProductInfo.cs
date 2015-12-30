using Luolu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luolu.Interface
{
    public interface IProductInfo : IService
    {
        List<ProductInfo> SearchBypage(int currpage, int pagesize);

        int Searchcount();
    }
}