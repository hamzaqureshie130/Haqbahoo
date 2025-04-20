using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IDashBoardService _dashboardService;
        public DashboardController(IDashBoardService dashBoardService)
        {
            _dashboardService = dashBoardService;
            
        }
        public async Task<IActionResult> Index()
        {
            var dashboard = new DashboardViewModel()
            {
                Dasboard = await _dashboardService.GetDashboard(),
            };
          
            return View(dashboard);
        }
    }
}
