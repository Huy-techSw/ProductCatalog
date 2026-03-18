using Microsoft.AspNetCore.Http;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ProductCatalog.Application.Services
{
    public class ProductImportService : IProductImportService
    {
        private readonly IProductRepository _repository;

        public ProductImportService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task ImportProductsAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();

            var products = await JsonSerializer.DeserializeAsync<List<Product>>(stream);

            if (products == null || products.Count == 0)
                throw new Exception("Invalid file");

            const int batchSize = 1000;

            for (int i = 0; i < products.Count; i += batchSize)
            {
                var batch = products.Skip(i).Take(batchSize).ToList();

                foreach (var product in batch)
                {
                    product.Id = Guid.NewGuid();
                    product.CreatedAt = DateTime.UtcNow;
                    product.UpdatedAt = DateTime.UtcNow;
                }

                await _repository.AddRangeAsync(batch);
            }
        }
    }
}
