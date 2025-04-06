using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using DomainLayer.Haqbahoo.ViewModel;
using InfrastructionLayer.Haqbahoo.IRepository;
using InfrastructionLayer.Haqbahoo.Repository;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Service
{
    public class InvoiceService:IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProductRepository _productRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IInventoryRepository _inventoryRepository;
       

        public InvoiceService(
            IInvoiceRepository invoiceRepository,
            IProductRepository productRepository,
            IInvoiceItemRepository invoiceItemRepository,
            ISaleItemRepository saleItemRepository,
            ISaleRepository saleRepository,
            IInventoryRepository inventoryRepository)
        {
            _invoiceRepository = invoiceRepository;
            _productRepository = productRepository;
            _invoiceItemRepository = invoiceItemRepository;
            _saleItemRepository = saleItemRepository;
            _saleRepository = saleRepository;
            _inventoryRepository = inventoryRepository;
            
        }

        public async Task<Invoice> GetInvoiceAsync(Guid id)
        {
            return await _invoiceRepository.GetInvoiceAsync(id);
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
           return await _invoiceRepository.GetAllInvoicesAsync();
        }
        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            try
            {
                // Generate invoice number and set creation date
                invoice.InvoiceNumber = await _invoiceRepository.GenerateInvoiceNumberAsync();
                invoice.CreatedDate = DateTime.UtcNow;

                // Calculate initial totals
                CalculateInvoiceTotals(invoice);
               
                // First save the invoice to get the ID
                var createdInvoice = await _invoiceRepository.CreateInvoiceAsync(invoice);

                // Process each invoice item
                foreach (var item in invoice.InvoiceItems)
                {

                    // Update product stock
                    var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                    if (product != null)
                    {
                        product.Quantity -= item.Quantity;
                        await _productRepository.UpdateProductAsync(product);
                    }
                    var sale = new Sale
                    {
                        SaleDate = invoice.CreatedDate,
                        TotalAmount = invoice.GrandTotal,
                        InvoiceNumber = invoice.InvoiceNumber
                    };

                    Guid saleId = await _saleRepository.AddSale(sale);

                    // Create Sale Item
                    var saleItem = new SaleItem
                    {
                        ProductId = item.ProductId,
                        SaleId = saleId,
                        Quantity = item.Quantity,
                        SellingPrice = item.Rate
                    };

                    bool result = await _saleItemRepository.AddSaleItem(saleItem);

                    // Update Inventory
                    var inventory = new Inventory
                    {
                        ProductId = item.ProductId,
                        QuantityIn = null,
                        QuantityOut = item.Quantity,
                        CreatedDate = DateTime.Now
                    };
                    await _inventoryRepository.AddQuantityOut(inventory);
                }
                // Create Sale
              
                return createdInvoice;
            }
            catch (Exception ex)
            {
                // Log the error here
                throw; // Re-throw the exception
            }
        }



        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            CalculateInvoiceTotals(invoice);
            await _invoiceRepository.UpdateInvoiceAsync(invoice);
        }

        public async Task DeleteInvoiceAsync(Guid id)
        {
            await _invoiceRepository.DeleteInvoiceAsync(id);
        }

        public async Task<InvoiceViewModel> GetNewInvoiceModelAsync()
        {
            var products = (await _productRepository.GetAllProductsAsync()).ToList();

            return new InvoiceViewModel
            {
                InvoiceNumber = "DRAFT",
                InvoiceDate = DateTime.Today,
                DueDate = DateTime.Today.AddDays(7),
                Products = products
            };
        }

        private void CalculateInvoiceTotals(Invoice invoice)
        {
            invoice.SubTotal = invoice.InvoiceItems.Sum(item => item.Amount);
            invoice.GrandTotal = invoice.SubTotal - invoice.Discount;
        }
    }
}

