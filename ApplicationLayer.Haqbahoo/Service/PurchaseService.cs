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
    public class PurchaseService:IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Guid> AddPurchase(Purchase purchase)
        {
           return await _purchaseRepository.AddPurchase(purchase);
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchase()
        {
           return await _purchaseRepository.GetAllPurchase();
        }

        public async Task<Purchase> GetPurchaseById(Guid purchaseId)
        {
        return await _purchaseRepository.GetPurchaseById(purchaseId);
        }
    }
}
