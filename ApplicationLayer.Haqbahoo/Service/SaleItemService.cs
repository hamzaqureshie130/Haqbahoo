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
    public class SaleItemService: ISaleItemService
    {
        private ISaleItemRepository _saleItemRepository;
        public SaleItemService(ISaleItemRepository saleItemRepository)
        {
            _saleItemRepository = saleItemRepository;

        }

        public async Task<bool> AddSaleItem(SaleItem saleItem)
        {
           return await _saleItemRepository.AddSaleItem(saleItem);
        }

        public async Task<SaleItem> GetSaleItemById(Guid saleItemId)
        {
            return await _saleItemRepository.GetSaleItemById(saleItemId);
        }


        public async Task<IEnumerable<SaleItem>> GetSaleItems()
        {
            return await _saleItemRepository.GetSaleItems();
        }
    }
}
