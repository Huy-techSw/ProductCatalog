using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.DTOs
{
    public class ProductSearchRequest
    {
        public string? Keyword { get; set; }

        public Guid? CategoryId { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public string? SortBy { get; set; } = "name";

        public bool IsDescending { get; set; } = false;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
