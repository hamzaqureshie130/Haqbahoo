using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using InfrastructionLayer.Haqbahoo.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.Repository
{
    class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly ApplicationDbContext _context;
        public CarFeatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCarFeature(CarFeature carFeature)
        {
             await _context.CarFeatures.AddAsync(carFeature);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task RemoveCarFeatures(Guid carId, List<Guid> featureIds)
        {
            var featuresToRemove = await _context.CarFeatures
                .Where(cf => cf.CarId == carId && featureIds.Contains(cf.FeatureId))
                .ToListAsync();

            if (featuresToRemove.Any())
            {
                _context.CarFeatures.RemoveRange(featuresToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EditCarFeature(CarFeature carFeature)
        {
           var carFeatureEntity = _context.CarFeatures.FirstOrDefault(x => x.Id == carFeature.Id);
            if (carFeatureEntity != null)
            {
                carFeatureEntity.FeatureId = carFeature.FeatureId;
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Guid>> GetCarFeatureById(Guid carId)
        {
            var selectedFeatureIds = await _context.CarFeatures
            .Where(cf => cf.CarId == carId) 
            .Select(cf => cf.FeatureId)     
            .ToListAsync();
            return selectedFeatureIds;
        }
    }
}
