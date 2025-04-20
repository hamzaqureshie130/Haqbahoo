using ApplicationLayer.Haqbahoo.IService;
using ApplicationLayer.Haqbahoo.Service;
using DomainLayer.Haqbahoo.Entities;
using DomainLayer.Haqbahoo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IFeatureService _featureService;
        private readonly ICategoryService _categoryService;
        private readonly ICarFeatureService _carFeatureService;

        public CarController(ICarService carService, IFeatureService featureService, ICategoryService categoryService, ICarFeatureService carFeatureService)
        {
            _carService = carService;
            _featureService = featureService;
            _categoryService = categoryService;
            _carFeatureService = carFeatureService;
        }
        
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCar();
            return View(cars);
        }
        public async Task<IActionResult> AddCar()
        {
            var carViewModel = new CarViewModel
            {
                Category = await _categoryService.GetAllCategory(),
                Features = await _featureService.GetAllFeature()
            };
            return View(carViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                if (carViewModel.Car.CoverImageFile == null)
                {
                    ModelState.AddModelError("Car.CoverImageFile", "Cover image is required.");
                }

                if (carViewModel.Car.GalleryImageFiles == null || !carViewModel.Car.GalleryImageFiles.Any())
                {
                    ModelState.AddModelError("Car.GalleryImageFiles", "At least one gallery image is required.");
                }
                var car = await _carService.AddCar(carViewModel.Car);

                if (carViewModel.SelectedFeatureIds != null && carViewModel.SelectedFeatureIds.Any())
                {
                    List<CarFeature> carFeatures = new List<CarFeature>();

                    foreach (var featureId in carViewModel.SelectedFeatureIds)
                    {
                        var carFeature = new CarFeature
                        {
                            Id = Guid.NewGuid(),
                            CarId = car.Id, // ✅ New Car Ki ID
                            FeatureId = featureId // ✅ Selected Feature Ki ID
                        };
                        await _carFeatureService.AddCarFeature(carFeature);
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            carViewModel.Category = await _categoryService.GetAllCategory();
            carViewModel.Features = await _featureService.GetAllFeature();
            return View(carViewModel);
        }

        public async Task<IActionResult> Edit(Guid carId)
        {
            var car = await _carService.GetCarById(carId);
           
            var carViewModel = new CarViewModel
            {
                Car = car,
                Category = await _categoryService.GetAllCategory(),
                SelectedFeatureIds = await _carFeatureService.GetCarFeatureById(carId),
                Features = await _featureService.GetAllFeature(),

            };
            return View(carViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                // If model is invalid, reload necessary data and return view
                carViewModel.Category = await _categoryService.GetAllCategory();
                carViewModel.Features = await _featureService.GetAllFeature();
                return View(carViewModel);
            }
            var car = await _carService.EditCar(carViewModel.Car);
            var existingFeatureIds = await _carFeatureService.GetCarFeatureById(car.Id);
            var selectedFeatureIds = carViewModel.SelectedFeatureIds ?? new List<Guid>(); // Prevent null
            var featuresToRemove = existingFeatureIds.Except(selectedFeatureIds).ToList();
            if (featuresToRemove.Any())
            {
                await _carFeatureService.RemoveCarFeatures(car.Id, featuresToRemove);
            }

         
            var featuresToAdd = selectedFeatureIds.Except(existingFeatureIds ?? new List<Guid>()).ToList();
            if (featuresToAdd.Any())
            {
                foreach (var featureId in featuresToAdd)
                {
                    var newCarFeature = new CarFeature
                    {
                        Id = Guid.NewGuid(),
                        CarId = car.Id,
                        FeatureId = featureId
                    };

                    await _carFeatureService.AddCarFeature(newCarFeature); // Call AddCarFeature method individually
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                bool status = await _carService.DeleteCar(id);
                return Redirect("/CRM/Car/Index");
            }
            return Redirect("/CRM/Car/Index");
        }
        [HttpPost]
        public async Task<IActionResult> InActive(Guid carId)
        {
            if(carId== Guid.Empty)
            {
                return Redirect("/CRM/Car/Index");
            }
            bool status =  await _carService.LockCar(carId);
            return Redirect("/CRM/Car/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Active(Guid carId)
        {
            if (carId == Guid.Empty)
            {
                return Redirect("/CRM/Car/Index");
            }
            bool status = await _carService.UnLockCar(carId);
            return Redirect("/CRM/Car/Index");
        }
    }
}
