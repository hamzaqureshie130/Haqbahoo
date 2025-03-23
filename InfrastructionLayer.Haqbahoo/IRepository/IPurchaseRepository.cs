using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
    public interface IPurchaseRepository
    {
        Task<Guid> AddPurchase(Purchase purchase);

        Task<Purchase> GetPurchaseById(Guid purchaseId);
        Task<IEnumerable<Purchase>> GetAllPurchase();
    }
}
