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
    public class PurchaseItemRepository:IPurchaseItemRepository
    {
        private readonly ApplicationDbContext _context;
        public PurchaseItemRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<bool> AddPurchaseItem(PurchaseItem purchaseItem)
        {
           await _context.AddAsync(purchaseItem);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PurchaseItem> GetPurchaseItemById(Guid purchaseItemId)
        {
           var purchaseItem = await _context.PurchaseItems.Include(x=>x.Product).Include(x=>x.Purchase).FirstOrDefaultAsync(x=>x.Id==purchaseItemId);
           if(purchaseItem != null)
            {
                return  purchaseItem;
            }
            return null;
        }

        public async Task<IEnumerable<PurchaseItem>> GetPurchaseItems()
        {
            return await _context.PurchaseItems.Include(x => x.Product).Include(x => x.Purchase).ToListAsync() ;
        }
    }
}
