using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
   public interface ISaleService
    {
        Task<Guid> AddSale(Sale sale);
       
        Task<Sale> GetSaleById(Guid saleId);
        Task<IEnumerable<Sale>> GetAllSale();
    }
}
