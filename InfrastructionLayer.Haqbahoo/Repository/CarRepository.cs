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
    class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car> AddCar(Car car)
        {
          await _context.Cars.AddAsync(car);
          await _context.SaveChangesAsync();
          return car;
        }

        public async Task<bool> DeleteCar(Guid carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Car> EditCar(Car car)
        {
            var carFromDb = await _context.Cars.FirstOrDefaultAsync(c => c.Id == car.Id);
            if (carFromDb != null)
            {
                carFromDb.Name = car.Name;
                carFromDb.RentPerDay = car.RentPerDay;
                carFromDb.CategoryId = car.CategoryId;
                carFromDb.Make = car.Make;
                carFromDb.Transmission = car.Transmission;
                carFromDb.Variant = car.Variant;
                carFromDb.Model = car.Model;
                if(car.CoverImageUrl != null)
                {
                    carFromDb.CoverImageUrl = car.CoverImageUrl;
                }
                _context.Cars.Update(carFromDb);
                 await _context.SaveChangesAsync() ;
                return car;
            }
            return null;
        }

        public async Task<IEnumerable<Car>> GetAllCar()
        {
          return await _context.Cars.Include(c => c.Category).Include(x => x.GalleryImages).Include(x => x.CarFeatures).ThenInclude(x => x.Feature).ToListAsync();
        }

        public async Task<Car> GetCarById(Guid carId)
        {
           var car = _context.Cars.Include(c => c.Category).Include(x=>x.GalleryImages).Include(x=>x.CarFeatures).ThenInclude(x=>x.Feature).FirstOrDefault(c => c.Id == carId);
            return car;
        }
    }
}
