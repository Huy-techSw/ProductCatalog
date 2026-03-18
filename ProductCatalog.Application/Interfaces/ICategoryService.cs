using ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task CreateCategoryAsync(Category category);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId);
    }
}
