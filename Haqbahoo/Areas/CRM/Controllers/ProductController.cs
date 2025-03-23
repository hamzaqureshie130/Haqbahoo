using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {  
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
          
            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                await _productService.DeleteProductAsync(id);
                return Redirect("/CRM/product/Index");
            }
            return Redirect("/CRM/product/Index");
        }
    }
}
