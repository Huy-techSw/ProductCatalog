using ProductCatalog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Inventory { get; set; }

        public Guid CategoryId { get; set; }

        public string ImageUrl { get; set; }

        public byte[] RowVersion { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductAttribute> Attributes { get; set; }
    }
}
