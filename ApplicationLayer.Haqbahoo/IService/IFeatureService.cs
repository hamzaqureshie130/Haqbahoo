using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
   public interface IFeatureService
    {
        Task<bool> AddFeature(Feature feature);
        Task<bool> DeleteFeature(Guid featureId);
        Task<bool> EditFeature(Feature feature);
        Task<Feature> GetFeatureById(Guid featureId);
        Task<IEnumerable<Feature>> GetAllFeature();
    }
}
