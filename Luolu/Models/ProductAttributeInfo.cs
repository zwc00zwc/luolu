using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Luolu.Models
{
    public class ProductAttributeInfo
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long AttributeId { get; set; }
        public long ValueId { get; set; }
        public string ValueName { get; set; }
    }
}