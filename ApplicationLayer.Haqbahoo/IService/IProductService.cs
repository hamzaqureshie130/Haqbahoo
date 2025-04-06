using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
    public interface IProductService
    {
        
            Task<IEnumerable<Product>> GetAllProductsAsync();
            Task<Product> GetProductByIdAsync(Guid id);
            Task<Product> AddProductAsync(Product product);
            Task UpdateProductAsync(Product product);
            Task DeleteProductAsync(Guid id);
        
    }
}
