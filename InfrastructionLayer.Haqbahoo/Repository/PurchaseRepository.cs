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
    public class PurchaseRepository: IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;
        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Guid> AddPurchase(Purchase purchase)
        {
          await _context.Purchases.AddAsync(purchase);
          await _context.SaveChangesAsync();
            return purchase.Id;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchase()
        {
            return await _context.Purchases.Include(x=>x.PurchaseItems).ToListAsync();
        }

        public Task<Purchase> GetPurchaseById(Guid purchaseId)
        {
            var purchase = _context.Purchases.Include(x => x.PurchaseItems).FirstOrDefaultAsync(x => x.Id == purchaseId);
            return purchase;
        }
    }
}
