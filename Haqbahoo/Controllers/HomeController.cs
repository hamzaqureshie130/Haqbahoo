using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Haqbahoo.Models;
using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.ViewModel;
using System.Threading.Tasks;

namespace Haqbahoo.Controllers;

public class HomeController : Controller
{
    private readonly ICarService _carService;
    private readonly IWorkShopService _workShopService;


    public HomeController(ICarService carService,IWorkShopService workShopService)
    {
        _carService = carService;
        _workShopService = workShopService;


    }

    public async Task<IActionResult> Index()
    {
        var homeViewModel = new HomeViewModel
        {
            Cars = await _carService.GetAllCar(),
            WorkShops = await _workShopService.GetAllWorkShop()


        };
        return View(homeViewModel);
    }

    public IActionResult AboutUs()
    {
        return View();
    }
    public IActionResult WorkShop()
    {
        return View();
    }
    public IActionResult CarList()
    {
        return View();
    }
    public IActionResult ContactUs()
    {
        return View();
    }
}
