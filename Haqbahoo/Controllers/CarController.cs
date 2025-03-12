using ApplicationLayer.Haqbahoo.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Haqbahoo.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;

        }
        public async Task<IActionResult> CarList()
        {
            var cars = await _carService.GetAllCar();
            return View(cars);
        }
        public async Task<IActionResult> Detail(Guid carId)
        {
            var car = await _carService.GetCarById(carId);
            return View(car);
        }
    }
}
