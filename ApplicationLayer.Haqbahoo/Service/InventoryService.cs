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
    public class InventoryService:IInventoryService
    {
        private IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<bool> AddQuantityIn(Inventory inventory)
        {
            return await _inventoryRepository.AddQuantityIn(inventory);
        }


        public async Task<bool> AddQuantityOut(Inventory inventory)
        {
            return await _inventoryRepository.AddQuantityOut(inventory);
        }

        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            return await _inventoryRepository.GetInventories();
        }

        public async Task<Inventory> GetInventoryById(Guid inventoryId)
        {
           return await _inventoryRepository.GetInventoryById(inventoryId);
        }
    }
}
