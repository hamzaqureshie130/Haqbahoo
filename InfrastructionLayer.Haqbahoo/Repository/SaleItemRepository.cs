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
    public class SaleItemRepository: ISaleItemRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleItemRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<bool> AddSaleItem(SaleItem saleItem)
        {
           await _context.AddAsync(saleItem);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<SaleItem> GetSaleItemById(Guid saleItemId)
        {
           var saleItem = await _context.SaleItems.Include(x=>x.Sale).Include(x=>x.Product).FirstOrDefaultAsync(x=>x.Id==saleItemId);
           if(saleItem != null)
            {
                return saleItem;
            }
            return null;
        }

        public async Task<IEnumerable<SaleItem>> GetSaleItems()
        {
            return await _context.SaleItems.Include(x => x.Sale).Include(x => x.Product).ToListAsync() ;
        }
    }
}
