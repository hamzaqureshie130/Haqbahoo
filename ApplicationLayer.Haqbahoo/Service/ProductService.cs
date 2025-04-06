using ApplicationLayer.Haqbahoo.Helper;
using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using Microsoft.CodeAnalysis;
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
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPurchaseItemRepository _purchaseItemRepository;
        

        public ProductService(IProductRepository productRepository,IInventoryRepository inventoryRepository,IPurchaseRepository purchaseRepository,IPurchaseItemRepository purchaseItemRepository)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _purchaseRepository = purchaseRepository;
            _purchaseItemRepository = purchaseItemRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {

            product.Code = GenerateUniqueProductCode();
            var newProduct =  await _productRepository.AddProductAsync(product);
            var inventory = new Inventory
            {
                ProductId = newProduct.Id,
                QuantityIn = newProduct.Quantity,
                QuantityOut = null,
                CreatedDate = DateTime.Now,
                

            };
            bool status = await _inventoryRepository.AddQuantityIn(inventory);
            var purchase = new Purchase
            {
                PurchaseDate = DateTime.Now,
                TotalAmount = product.Quantity * product.PurchasePrice,
                InvoiceNumber = await GenerateInvoiceNumber(),

            };
            Guid purchaseId = await _purchaseRepository.AddPurchase(purchase);


            var purchaseItem = new PurchaseItem
            {
                ProductId = product.Id,
                PurchaseId = purchaseId,
                Quantity = product.Quantity,
                PurchasingPrice = product.PurchasePrice
            };
            bool result = await _purchaseItemRepository.AddPurchaseItem(purchaseItem);
            return newProduct;
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
        private async Task<string> GenerateInvoiceNumber()
        {
            // Find the latest invoice number in the database
            var purchases = await _purchaseRepository.GetAllPurchase();
            var lastInvoice = purchases.OrderByDescending(p => p.PurchaseDate).FirstOrDefault();

            if (lastInvoice == null || string.IsNullOrEmpty(lastInvoice.InvoiceNumber))
            {
                return "INV00001";
            }

            // Extract numeric part and increment
            string lastNumber = lastInvoice.InvoiceNumber.Substring(3);
            int nextNumber = int.Parse(lastNumber) + 1;

            // Return formatted invoice number
            return $"INV{nextNumber:D5}";
        }
    }

}
