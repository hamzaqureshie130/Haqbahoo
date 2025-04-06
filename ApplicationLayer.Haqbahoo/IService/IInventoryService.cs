using DomainLayer.Haqbahoo.Entities;
using DomainLayer.Haqbahoo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
    public interface IInventoryService
    {
        Task<bool> AddQuantityIn(Inventory inventory);
        Task<bool> AddQuantityOut(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventories();
        Task<Inventory> GetInventoryById(Guid inventoryId);

        Task<IEnumerable<InventoryViewModel>> GetStockReport();
    }
}
