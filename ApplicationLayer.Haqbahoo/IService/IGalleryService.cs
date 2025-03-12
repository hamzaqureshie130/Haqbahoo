using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
   public interface IGalleryService
    {
        Task<bool> AddGallery(Gallery gallery);
        Task<bool> DeleteGallery(Guid galleryId);
        Task<bool> EditGallery(Gallery gallery);
        Task<IEnumerable<Gallery>> GetCarImagesById(Guid carId);
        Task<IEnumerable<Gallery>> GetAllCarGallery(Guid carId);
    }
}
