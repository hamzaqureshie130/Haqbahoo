using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Haqbahoo.Models;
using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.ViewModel;

namespace Haqbahoo.Controllers;

public class HomeController : Controller
{
    private readonly ICarService _carService;


    public HomeController(ICarService carService)
    {
        _carService = carService;


    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            Cars = _carService.GetAllCar().Result
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
