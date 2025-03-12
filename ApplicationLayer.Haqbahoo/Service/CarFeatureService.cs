using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Service
{
    public class CarFeatureService : ICarFeatureService
    {
        private ICarFeatureRepository _carFeatureRepository;
        public CarFeatureService(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<bool> AddCarFeature(CarFeature carFeature)
        {
            return await _carFeatureRepository.AddCarFeature(carFeature);
        }

      

        public async Task<bool> EditCarFeature(CarFeature carFeature)
        {
            return await _carFeatureRepository.EditCarFeature(carFeature);
        }

        public async Task<IEnumerable<Guid>> GetCarFeatureById(Guid carId)
        {
            return await _carFeatureRepository.GetCarFeatureById(carId);
        }

        public async Task RemoveCarFeatures(Guid carId, List<Guid> featureIds)
        {
            await _carFeatureRepository.RemoveCarFeatures(carId, featureIds);
        }
    }
}
