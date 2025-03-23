using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
    public interface IPurchaseItemService
    {
        Task<bool> AddPurchaseItem(PurchaseItem purchaseItem);
        Task<IEnumerable<PurchaseItem>> GetPurchaseItems();
        Task<PurchaseItem> GetPurchaseItemById(Guid purchaseItemId);
    }
}
