using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
   public interface ICarRepository
    {
        Task<Car> AddCar(Car car);
        Task<bool> DeleteCar(Guid carId);
        Task<Car> EditCar(Car car);
        Task<Car> GetCarById(Guid carId);
        Task<IEnumerable<Car>> GetAllCar();
    }
}
