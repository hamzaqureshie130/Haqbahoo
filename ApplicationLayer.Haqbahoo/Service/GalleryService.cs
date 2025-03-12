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
    public class GalleryService : IGalleryService
    {
        private IGalleryRepository _galleryRepository;
        public GalleryService(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public async Task<bool> AddGallery(Gallery gallery)
        {
            return await _galleryRepository.AddGallery(gallery);
        }

        public async Task<bool> DeleteGallery(Guid galleryId)
        {
            return await _galleryRepository.DeleteGallery(galleryId);
        }

        public async Task<bool> EditGallery(Gallery gallery)
        {
            return await _galleryRepository.EditGallery(gallery);
        }

        public async Task<IEnumerable<Gallery>> GetAllCarGallery(Guid carId)
        {
          return await _galleryRepository.GetAllCarGallery(carId);
        }

        public async  Task<IEnumerable<Gallery>> GetCarImagesById(Guid carId)
        {
            return await _galleryRepository.GetCarImagesById(carId);
        }
    }
}
