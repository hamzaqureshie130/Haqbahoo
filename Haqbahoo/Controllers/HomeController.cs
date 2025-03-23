using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Haqbahoo.Models;
using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.ViewModel;
using System.Threading.Tasks;
using DomainLayer.Haqbahoo.Entities;

namespace Haqbahoo.Controllers;

public class HomeController : Controller
{
    private readonly ICarService _carService;
    private readonly IWorkShopService _workShopService;
    private readonly IFeedbackService _feedbackService;


    public HomeController(ICarService carService,IWorkShopService workShopService,IFeedbackService feedbackService)
    {
        _carService = carService;
        _workShopService = workShopService;
        _feedbackService = feedbackService;
    }

    public async Task<IActionResult> Index()
    {
        var homeViewModel = new HomeViewModel
        {
            Cars = await _carService.GetAllCar(),
            WorkShops = await _workShopService.GetAllWorkShop(),
            Feedbacks = await _feedbackService.GetAllFeedback()


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
    [HttpPost]
    public IActionResult AddFeedback(Feedback feedback)
    {
        var status = _feedbackService.AddFeedback(feedback);
        return RedirectToAction("Index");
    }

}

