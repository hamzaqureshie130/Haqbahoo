using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using Haqbahoo.Helper;
using InfrastructionLayer.Haqbahoo.IRepository;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Service
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;
        private readonly IGalleryService _galleryService;
        private FileUploader _fileUploader;
        public CarService(ICarRepository carRepository,FileUploader fileUploader, IGalleryService galleryService)
        {
            _carRepository = carRepository;
            _fileUploader = fileUploader;
            _galleryService = galleryService;
        }

        public async Task<Car> AddCar(Car car)
        {
            if (car.CoverImageFile != null)
            {
                var newImageResult = await _fileUploader.UploadFile(car.CoverImageFile);
                if (newImageResult.status)
                {
                    car.CoverImageUrl = newImageResult.url;
                }
            }
            

             await _carRepository.AddCar(car);
            if (car.GalleryImageFiles != null && car.GalleryImageFiles.Any())
            {



                foreach (var galleryImage in car.GalleryImageFiles)
                {

                    var newImageResult = await _fileUploader.UploadFile(galleryImage);
                    if (newImageResult.status)
                    {
                        var galleryObject = new Gallery();
                        {
                            galleryObject.Id = Guid.NewGuid();
                            galleryObject.ImageUrl = newImageResult.url;
                            galleryObject.CarId = car.Id;
                        }

                        bool status = await _galleryService.AddGallery(galleryObject);
                    }

                }
            }
            return car;
        }

        public async Task<bool> DeleteCar(Guid carId)
        {
          return await _carRepository.DeleteCar(carId);
        }

        public async Task<Car> EditCar(Car car)
        {
            if (car.CoverImageFile != null)
            {
                var newImageResult = await _fileUploader.UploadFile(car.CoverImageFile);
                if (newImageResult.status)
                {
                    car.CoverImageUrl = newImageResult.url;
                }
            }
            await _carRepository.EditCar(car);
            if (car.GalleryImageFiles != null && car.GalleryImageFiles.Any())
            {
                var existingGallery = (await _galleryService.GetCarImagesById(car.Id)).ToList();
                int existingGalleryCount = existingGallery.Count();

                // Update existing galleries
                for (int i = 0; i < existingGalleryCount && i < car.GalleryImageFiles.Count; i++)
                {
                    var result = await _fileUploader.UploadFile(car.GalleryImageFiles[i]);
                    if (result.status)
                    {
                        existingGallery[i].ImageUrl = result.url;
                        await _galleryService.EditGallery(existingGallery[i]);
                    }
                }

                // Add new galleries for the remaining images
                for (int i = existingGalleryCount; i < car.GalleryImageFiles.Count; i++)
                {
                    var result = await _fileUploader.UploadFile(car.GalleryImageFiles[i]);
                    if (result.status)
                    {
                        var newGallery = new Gallery
                        {
                            ImageUrl = result.url,
                            CarId = car.Id
                        };
                        await _galleryService.AddGallery(newGallery);
                    }
                }


            }
            return car;
        }

        public async Task<IEnumerable<Car>> GetAllCar()
        {
           return await _carRepository.GetAllCar();
        }

        public async Task<Car> GetCarById(Guid carId)
        {
            return await _carRepository.GetCarById(carId);
        }

        public async Task<List<Car>> GetAllActiveCar()
        {
           return await _carRepository.GetAllActiveCar();
        }

        public async Task<List<Car>> GetAllInActiveCar()
        {
           return await _carRepository.GetAllInActiveCar();
        }

        public async Task<bool> LockCar(Guid carId)
        {
           return await _carRepository.LockCar(carId);
        }

        public async Task<bool> UnLockCar(Guid carId)
        {
           return await _carRepository.UnLockCar(carId);
        }
    }
}
