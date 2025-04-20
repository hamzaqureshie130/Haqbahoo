using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    [Authorize(Roles = "Admin")]
    public class PurchaseItemController : Controller
    {
        private readonly IPurchaseItemService _purchaseItemService;
        private readonly IProductService _productService;
        private readonly IPurchaseService _purchaseService;
        private readonly IInventoryService _inventoryService;
        public PurchaseItemController(IPurchaseItemService purchaseItemService, IProductService productService,IPurchaseService purchaseService, IInventoryService inventoryService)
        {
            _purchaseItemService = purchaseItemService;
            _purchaseService = purchaseService;
            _productService = productService;
            _inventoryService = inventoryService;
        }
        public async Task<IActionResult> Index()
        {
            var purchases = await _purchaseItemService.GetPurchaseItems();
            return View(purchases);
        }
        [HttpPost]
        public async Task<IActionResult> Purchase(Guid productId, int quantity, decimal purchasePrice)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null) return NotFound();

            product.Quantity += quantity;
            await _productService.UpdateProductAsync(product);

            var purchase = new Purchase
            {
                PurchaseDate = DateTime.Now,
                TotalAmount = quantity * purchasePrice,
                InvoiceNumber = await GenerateInvoiceNumber(),

            };
            Guid purchaseId =  await _purchaseService.AddPurchase(purchase);


            var purchaseItem = new PurchaseItem
            {
                ProductId = productId,
                PurchaseId = purchaseId,
                Quantity = quantity,
                PurchasingPrice = purchasePrice
            };
            bool result = await _purchaseItemService.AddPurchaseItem(purchaseItem);
            var inventory = new Inventory
            {
                ProductId = productId,
                QuantityIn = quantity,
                QuantityOut = null,
                CreatedDate = DateTime.Now
            };
            await _inventoryService.AddQuantityIn(inventory);

            // Add logic to save the purchase item if needed
            return Json(new { success = true });
        }
        // Generate Unique Invoice Number
        private async Task<string> GenerateInvoiceNumber()
        {
            // Find the latest invoice number in the database
            var purchases = await _purchaseService.GetAllPurchase();
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
