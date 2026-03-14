using ProductCatalog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Category> Children { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
