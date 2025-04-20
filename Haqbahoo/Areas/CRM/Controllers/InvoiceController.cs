using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using DomainLayer.Haqbahoo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    [Authorize(Roles = "Admin")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _productService;
        
        public InvoiceController(IInvoiceService invoiceService,IProductService productService)
        {
            _invoiceService = invoiceService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return View(invoices);
        }

        public async Task<IActionResult> Create()
        {
            var model = await _invoiceService.GetNewInvoiceModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Products = (await _productService.GetAllProductsAsync()).ToList();
                return View(model);
            }

            var invoice = new Invoice
            {
                CustomerType = model.CustomerType,
                InvoiceDate = model.InvoiceDate,
                DueDate = model.DueDate,
               Discount = model.Discount,

                InvoiceItems = model.Items.Select(i => new InvoiceItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Unit = i.Unit,
                    Rate = i.Rate,
                    Discount = i.Discount,
                    Amount = i.Amount
                }).ToList()
            };

            var createdInvoice = await _invoiceService.CreateInvoiceAsync(invoice);
            return RedirectToAction("PrintInvoice", new { id = createdInvoice.Id });
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var invoice = await _invoiceService.GetInvoiceAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }
        public async Task<IActionResult> PrintInvoice(Guid id)
        {
            var invoice = await _invoiceService.GetInvoiceAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

    }
}

