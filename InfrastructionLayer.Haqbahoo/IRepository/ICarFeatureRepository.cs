using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
   public interface ICarFeatureRepository
    {
        Task<bool> AddCarFeature(CarFeature carFeature);
        Task RemoveCarFeatures(Guid carId, List<Guid> featureIds);
        Task<bool> EditCarFeature(CarFeature carFeature);
        Task<IEnumerable<Guid>> GetCarFeatureById(Guid carId);
    }
}
