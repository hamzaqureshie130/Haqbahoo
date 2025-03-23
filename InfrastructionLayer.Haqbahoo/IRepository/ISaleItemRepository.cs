using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
    public interface ISaleItemRepository
    {
        Task<bool> AddSaleItem(SaleItem saleItem);
        Task<IEnumerable<SaleItem>> GetSaleItems();
        Task<SaleItem> GetSaleItemById(Guid saleItemId);
    }
}
