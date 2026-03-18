using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Common
{
    namespace ProductCatalog.Domain.Common
    {
        public class ProductSearchCriteria
        {
            public string? Keyword { get; set; }
            public Guid? CategoryId { get; set; }
            public decimal? MinPrice { get; set; }
            public decimal? MaxPrice { get; set; }
            public string? SortBy { get; set; }
            public bool IsDescending { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
    }
}
