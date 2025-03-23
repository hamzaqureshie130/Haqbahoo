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
    public class PurchaseItemService:IPurchaseItemService
    {
        private IPurchaseItemRepository _purchaseItemRepository;
        public PurchaseItemService(IPurchaseItemRepository purchaseItemRepository)
        {
            _purchaseItemRepository = purchaseItemRepository;

        }

        public async Task<bool> AddPurchaseItem(PurchaseItem purchaseItem)
        {
           return await _purchaseItemRepository.AddPurchaseItem(purchaseItem);
        }

        public async Task<PurchaseItem> GetPurchaseItemById(Guid purchaseItemId)
        {
            return await _purchaseItemRepository.GetPurchaseItemById(purchaseItemId);
        }

        public async Task<IEnumerable<PurchaseItem>> GetPurchaseItems()
        {
            return await _purchaseItemRepository.GetPurchaseItems();
        }
    }
}
