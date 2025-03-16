using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    public class WorkShopController : Controller
    {
        private readonly IWorkShopService _workShopService;
        public WorkShopController(IWorkShopService workShopService)
        {
            _workShopService = workShopService;

        }
        public async Task<IActionResult> Index()
        {
            var workshop = await _workShopService.GetAllWorkShop();
            return View(workshop);
        }
        public IActionResult AddWorkShop()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkShop(WorkShop workshop)
        {
            if (!ModelState.IsValid)
            {
                return View(workshop);
            }
            if(workshop.CoverImageFile == null)
            {
               ModelState.AddModelError("CoverImageFile", "Please upload Image!");
                return View(workshop);

            }
            await _workShopService.AddWorkShop(workshop);
            return Redirect("/crm/workshop/Index");
        }
        public async Task<IActionResult> Edit(Guid workshopId)
        {
            var workshop = await _workShopService.GetWorkShopById(workshopId);
            return View(workshop);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkShop workshop)
        {
            if (!ModelState.IsValid)
            {
                return View(workshop);
            }
            bool status = await _workShopService.EditWorkShop(workshop);
            return Redirect("/CRM/workshop/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                bool status = await _workShopService.DeleteWorkShop(id);
                return Redirect("/crm/workshop/Index");
            }
            return Redirect("/crm/workshop/Index");
        }
    }
}
