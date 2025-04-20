using ApplicationLayer.Haqbahoo.IService;
using InfrastructionLayer.Haqbahoo.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    [Authorize(Roles = "Admin")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;

        }
        public async Task<IActionResult> Index()
        {
            var inventories = await _inventoryService.GetStockReport();
            return View(inventories);
        }
    }
}
