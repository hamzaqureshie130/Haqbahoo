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
    class GalleryRepository : IGalleryRepository
    {
        private readonly ApplicationDbContext _context;
        public GalleryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddGallery(Gallery gallery)
        {
            await _context.Galleries.AddAsync(gallery);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGallery(Guid galleryId)
        {
            var gallery = await _context.Galleries.FindAsync(galleryId);
            if (gallery != null)
            {
                _context.Galleries.Remove(gallery);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> EditGallery(Gallery gallery)
        {
            var galleryFromDb = await _context.Galleries.FindAsync(gallery.Id);
            if (galleryFromDb != null)
            {
                galleryFromDb.ImageUrl = gallery.ImageUrl;
                _context.Galleries.Update(galleryFromDb);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Gallery>> GetAllCarGallery(Guid carId)
        {
            return await _context.Galleries.Where(x=>x.CarId==carId).ToListAsync();
        }

        public async Task<IEnumerable<Gallery>> GetCarImagesById(Guid carId)
        {
            return await _context.Galleries.Where(x => x.CarId == carId).ToListAsync();
        }
    }
}
