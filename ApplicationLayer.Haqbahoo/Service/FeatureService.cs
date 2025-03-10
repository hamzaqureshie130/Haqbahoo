using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using Haqbahoo.Helper;
using InfrastructionLayer.Haqbahoo.IRepository;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Service
{
    public class FeatureService : IFeatureService
    {
        private IFeatureRepository _featureRepository;
        private FileUploader _fileUploader;
        public FeatureService(IFeatureRepository featureRepository,FileUploader fileUploader)
        {
            _featureRepository = featureRepository;
            _fileUploader = fileUploader;
        }

        public async Task<bool> AddFeature(Feature feature)
        {
            if (feature.ImageFile != null)
            {
                var newImageResult = await _fileUploader.UploadFile(feature.ImageFile);
                if (newImageResult.status)
                {
                    feature.ImageUrl = newImageResult.url;
                }
            }
            return await _featureRepository.AddFeature(feature);
        }

        public async Task<bool> DeleteFeature(Guid featureId)
        {
            return await _featureRepository.DeleteFeature(featureId);
        }

        public async Task<bool> EditFeature(Feature feature)
        {
            if (feature.ImageFile != null)
            {
                var newImageResult = await _fileUploader.UploadFile(feature.ImageFile);
                if (newImageResult.status)
                {
                    feature.ImageUrl = newImageResult.url;
                }
            }
            return await _featureRepository.EditFeature(feature);
        }

        public async Task<IEnumerable<Feature>> GetAllFeature()
        {
          return await _featureRepository.GetAllFeature();
        }

        public async Task<Feature> GetFeatureById(Guid featureId)
        {
            return await _featureRepository.GetFeatureById(featureId);
        }
    }
}
