using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using InfrastructionLayer.Haqbahoo.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.Repository
{
    public class SaleRepository: ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Guid> AddSale(Sale sale)
        {
          await _context.Sales.AddAsync(sale);
          await _context.SaveChangesAsync();
            return sale.Id;
        }

        public async Task<IEnumerable<Sale>> GetAllSale()
        {
            return await _context.Sales.Include(x=>x.SaleItems).ToListAsync();
        }

        public Task<Sale> GetSaleById(Guid saleId)
        {
            var sale = _context.Sales.Include(x => x.SaleItems).FirstOrDefaultAsync(x => x.Id == saleId);
            return sale;
        }
    }
}
