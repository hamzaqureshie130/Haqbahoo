using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
    public interface ISaleRepository
    {
        Task<Guid> AddSale(Sale sale);

        Task<Sale> GetSaleById(Guid saleId);
        Task<IEnumerable<Sale>> GetAllSale();
    }
}
