using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Haqbahoo.Models;

namespace Haqbahoo.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
        
    }

    public IActionResult Index()
    {
        return View();
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
