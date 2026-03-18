using ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(
            int page,
            int pageSize,
            string? keyword,
            Guid? categoryId);

        Task<Product?> GetByIdAsync(Guid id);

        Task AddAsync(Product product);

        Task AddRangeAsync(IEnumerable<Product> products);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);

    }
}
