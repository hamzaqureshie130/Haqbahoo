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
    public class SaleService: ISaleService
    {
        private ISaleRepository _saleRepository;
        public SaleService(ISaleRepository SaleRepository)
        {
            _saleRepository = SaleRepository;
        }

        public async Task<Guid> AddSale(Sale Sale)
        {
           return await _saleRepository.AddSale(Sale);
        }

        public async Task<IEnumerable<Sale>> GetAllSale()
        {
           return await _saleRepository.GetAllSale();
        }

        public async Task<Sale> GetSaleById(Guid SaleId)
        {
        return await _saleRepository.GetSaleById(SaleId);
        }
    }
}
