using ApplicationLayer.Haqbahoo.Helper;
using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {

            product.Code = GenerateUniqueProductCode();
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
        private  string GenerateUniqueProductCode()
        {
            // Example: "PRD" + Random 6-Digit Number (e.g., PRD123456)

            return $"PRD{new Random().Next(100000, 999999)}";
        }
    }

}
