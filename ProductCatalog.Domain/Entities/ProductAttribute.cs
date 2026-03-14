using ProductCatalog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Entities
{
    public class ProductAttribute : BaseEntity
    {
        public Guid ProductId { get; set; }

        public string AttributeName { get; set; }

        public string AttributeValue { get; set; }

        public Product Product { get; set; }
    }
}
