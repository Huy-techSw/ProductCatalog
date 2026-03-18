using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Common;
using ProductCatalog.Domain.Common.ProductCatalog.Domain.Common;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(
            int page,
            int pageSize,
            string? keyword,
            Guid? categoryId)
        {
            var query = _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                .Include(p => p.Attributes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Product> products)
        {
            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(ProductSearchCriteria request)
        {
            var query = _context.Products.AsQueryable();

            // Keyword
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(p =>
                    p.Name.Contains(request.Keyword) ||
                    p.Description.Contains(request.Keyword));
            }

            // Category
            if (request.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == request.CategoryId);
            }

            // Price range
            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinPrice);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaxPrice);
            }

            // Sorting
            query = request.SortBy?.ToLower() switch
            {
                "price" => request.IsDescending
                    ? query.OrderByDescending(p => p.Price)
                    : query.OrderBy(p => p.Price),

                "created" => request.IsDescending
                    ? query.OrderByDescending(p => p.CreatedAt)
                    : query.OrderBy(p => p.CreatedAt),

                _ => request.IsDescending
                    ? query.OrderByDescending(p => p.Name)
                    : query.OrderBy(p => p.Name)
            };

            // Pagination
            query = query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize);

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
