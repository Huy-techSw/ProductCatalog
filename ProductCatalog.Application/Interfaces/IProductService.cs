using ProductCatalog.Application.DTOs;
using ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync(
            int page,
            int pageSize,
            string? keyword,
            Guid? categoryId);

        Task<Product?> GetProductByIdAsync(Guid id);

        Task CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(Guid id);

        Task<IEnumerable<Product>> SearchAsync(ProductSearchRequest request);
    }
}
