using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Haqbahoo.Controllers
{

    public class WorkShopController : Controller
    {
        private readonly IWorkShopService _workShopService;
        public WorkShopController(IWorkShopService workShopService)
        {
            _workShopService = workShopService;

        }

        public async Task<IActionResult> List()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            {
                homeViewModel.WorkShops = await _workShopService.GetAllWorkShop();
            }
            return View(homeViewModel);
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var workshop = await _workShopService.GetWorkShopById(id);
            return View(workshop);
        }

    }
}
