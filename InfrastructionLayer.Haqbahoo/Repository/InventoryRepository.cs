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
    public class InventoryRepository:IInventoryRepository
    {
        private readonly ApplicationDbContext _context;
        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<bool> AddQuantityIn(Inventory inventory)
        {
            await _context.AddAsync(inventory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddQuantityOut(Inventory inventory)
        {
            await _context.AddAsync(inventory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            return await _context.Inventories.Include(x => x.Product).ToListAsync();
        }

        public async Task<Inventory> GetInventoryById(Guid inventoryId)
        {
            var inventory = await _context.Inventories.Include(x => x.Product).Where(x => x.Id == inventoryId).FirstOrDefaultAsync();
            if (inventory != null)
            {
                return inventory;
            }
            return null;
        }

        public async Task<IEnumerable<object>> GetStockReport()
        {
            var stockReport = (from p in _context.Products
                               join i in _context.Inventories on p.Id equals i.ProductId into inventoryGroup
                               from ig in inventoryGroup.DefaultIfEmpty()
                               group ig by new { p.Id, p.Title, p.Code, p.Quantity } into g
                               select new
                               {
                                   ProductId = g.Key.Id,
                                   ProductTitle = g.Key.Title,
                                   ProductCode = g.Key.Code,
                                   TotalQuantityIn = g.Sum(x => x.QuantityIn ?? 0),
                                   TotalQuantityOut = g.Sum(x => x.QuantityOut ?? 0),
                                   CurrentStock = g.Key.Quantity + g.Sum(x => x.QuantityIn ?? 0) - g.Sum(x => x.QuantityOut ?? 0),
                                   InitialStock = g.Key.Quantity,  // Assuming Quantity is initial stock in Product
                                   LastUpdated = g.Max(x => x.LastUpdated)
                               })
                .OrderBy(r => r.ProductTitle)
                .ToList();

            return stockReport;
        }

    }
}
