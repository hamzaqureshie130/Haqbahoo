using DomainLayer.Haqbahoo.Entities;
using DomainLayer.Haqbahoo.ViewModel;
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

        public async Task<IEnumerable<InventoryViewModel>> GetStockReport()
        {
            var result = from p in _context.Products
                         join i in _context.Inventories on p.Id equals i.ProductId into inventoryGroup
                         from inv in inventoryGroup.DefaultIfEmpty()
                         group inv by new { p.Id, p.Code, p.Title } into g
                         select new InventoryViewModel
                         {
                             ProductId = g.Key.Id,
                             Code = g.Key.Code,
                             Title = g.Key.Title,
                             QuantityIn = g.Sum(i => (i != null ? i.QuantityIn : 0) ?? 0),
                             QuantityOut = g.Sum(i => (i != null ? i.QuantityOut : 0) ?? 0),
                             QuantityAvailable =
                                (g.Sum(i => (i != null ? i.QuantityIn : 0) ?? 0) -
                                 g.Sum(i => (i != null ? i.QuantityOut : 0) ?? 0))
                         };

            return await result.ToListAsync();
        }



    }

}
