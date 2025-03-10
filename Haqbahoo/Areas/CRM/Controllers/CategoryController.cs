using ApplicationLayer.Haqbahoo.IService;
using ApplicationLayer.Haqbahoo.Service;
using DomainLayer.Haqbahoo.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryService.GetAllCategory();
            return View(category);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            await _categoryService.AddCategory(category);
            return Redirect("/CRM/Category/Index");
        }
        public async Task<IActionResult> Edit(Guid categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            bool status = await _categoryService.EditCategory(category);
            return Redirect("/CRM/Category/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            if(categoryId != Guid.Empty)
            {
                bool status = await _categoryService.DeleteCategory(categoryId);
                return Redirect("/CRM/Category/Index");
            }
            return Redirect("/CRM/Category/Index");
        }
    }
}
