using Luolu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luolu.Interface
{
    public interface IProductAttributeInfo
    {
        List<ProductAttributeInfo> SearchByproductid(string id);
    }
}