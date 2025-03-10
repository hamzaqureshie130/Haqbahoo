using Microsoft.AspNetCore.Mvc;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
