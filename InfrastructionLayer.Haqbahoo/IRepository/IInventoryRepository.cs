using DomainLayer.Haqbahoo.Entities;
using DomainLayer.Haqbahoo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
    public interface IInventoryRepository
    {
        Task<bool> AddQuantityIn(Inventory inventory);
        Task<bool> AddQuantityOut(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventories();
        Task<Inventory> GetInventoryById(Guid inventoryId);
        Task<IEnumerable<InventoryViewModel>> GetStockReport();
    }
}
