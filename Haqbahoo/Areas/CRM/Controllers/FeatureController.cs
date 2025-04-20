using ApplicationLayer.Haqbahoo.IService;
using ApplicationLayer.Haqbahoo.Service;
using DomainLayer.Haqbahoo.Entities;
using Haqbahoo.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.Sig;
using Stripe.Entitlements;
using System.Threading.Tasks;

namespace Haqbahoo.Areas.CRM.Controllers
{
    [Area("CRM")]
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
     
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
       

        }
        public async Task<IActionResult> Index()
        {
            var feature = await _featureService.GetAllFeature();
            return View(feature);
        }
        public IActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFeature(DomainLayer.Haqbahoo.Entities.Feature feature)
        {
            if(feature.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile","Please upload an Image");
            }
            if(!ModelState.IsValid)
            {
                return View(feature);
            }
          
            await _featureService.AddFeature(feature);
            return Redirect("/CRM/Feature/Index");
        }
        public async Task<IActionResult> Edit(Guid featureId)
        {
            var feature = await _featureService.GetFeatureById(featureId);
            return View(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DomainLayer.Haqbahoo.Entities.Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View(feature);
            }
            bool status = await _featureService.EditFeature(feature);
            return Redirect("/CRM/Feature/Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(id != Guid.Empty)
            {
                bool status = await _featureService.DeleteFeature(id);
                return Redirect("/CRM/Feature/Index");
            }
            return Redirect("/CRM/Feature/Index");
        }
    }
}
