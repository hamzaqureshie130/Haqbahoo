using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    public class SaleItemController : Controller
    {
        private readonly ISaleItemService _saleItemService;
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly IInventoryService _inventoryService;

        public SaleItemController(ISaleItemService saleItemService, IProductService productService, ISaleService saleService, IInventoryService inventoryService)
        {
            _saleItemService = saleItemService;
            _productService = productService;
            _inventoryService = inventoryService;
            _saleService = saleService;
        }

        public async Task<IActionResult> Index()
        {
            var sales = await _saleItemService.GetSaleItems();
            return View(sales);
        }

        [HttpPost]
        public async Task<IActionResult> Sell(Guid productId, int quantity, decimal salePrice)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null) return NotFound();

            // Check if enough quantity is available to sell
            if (product.Quantity < quantity)
            {
                return Json(new { success = false, message = "Not enough stock available!" });
            }

            // Reduce product quantity
            product.Quantity -= quantity;
            await _productService.UpdateProductAsync(product);

            // Generate unique invoice number
            string invoiceNumber = await GenerateInvoiceNumber();

            // Create Sale
            var sale = new Sale
            {
                SaleDate = DateTime.Now,
                TotalAmount = quantity * salePrice,
                InvoiceNumber = invoiceNumber
            };

            Guid saleId = await _saleService.AddSale(sale);

            // Create Sale Item
            var saleItem = new SaleItem
            {
                ProductId = productId,
                SaleId = saleId,
                Quantity = quantity,
                SellingPrice = salePrice
            };

            bool result = await _saleItemService.AddSaleItem(saleItem);

            // Update Inventory
            var inventory = new Inventory
            {
                ProductId = productId,
                QuantityIn = null,
                QuantityOut = quantity,
                CreatedDate = DateTime.Now
            };
            await _inventoryService.AddQuantityOut(inventory);

            return Json(new { success = true });
        }

        // Generate Unique Invoice Number
        private async Task<string> GenerateInvoiceNumber()
        {
            var sales = await _saleService.GetAllSale();
            var lastInvoice = sales.OrderByDescending(s => s.SaleDate).FirstOrDefault();

            if (lastInvoice == null || string.IsNullOrEmpty(lastInvoice.InvoiceNumber))
            {
                return "SINV00001";
            }

            string lastNumber = lastInvoice.InvoiceNumber.Substring(4);
            int nextNumber = int.Parse(lastNumber) + 1;

            return $"SINV{nextNumber:D5}";
        }
    }
}
