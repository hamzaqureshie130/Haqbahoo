using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
   public interface IWorkShopRepository
    {
        Task<bool> AddWorkShop(WorkShop workShop);
        Task<bool> DeleteWorkShop(Guid workShopId);
        Task<bool> EditWorkShop(WorkShop workShop);
        Task<WorkShop> GetWorkShopById(Guid WorkShopId);
        Task<IEnumerable<WorkShop>> GetAllWorkShop();
    }
}
