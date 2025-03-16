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
    class WorkShopRepository : IWorkShopRepository
    {
        private readonly ApplicationDbContext _context;
        public WorkShopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddWorkShop(WorkShop workShop)
        {
            await _context.Workshop.AddAsync(workShop);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteWorkShop(Guid workShopId)
        {
            var workShop = await _context.Workshop.FindAsync(workShopId);
            if (workShop != null)
            {
                _context.Workshop.Remove(workShop);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> EditWorkShop(WorkShop workShop)
        {
            var workShopFromDb = await _context.Workshop.FindAsync(workShop.Id);
            if (workShopFromDb != null)
            {
                workShopFromDb.Title = workShop.Title;
                workShopFromDb.Description = workShop.Description;
                if(workShop.CoverImageUrl != null)
                {
                    workShopFromDb.CoverImageUrl = workShop.CoverImageUrl;
                }
                _context.Workshop.Update(workShopFromDb);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<IEnumerable<WorkShop>> GetAllWorkShop()
        {
            return await _context.Workshop.ToListAsync();
        }

        public async Task<WorkShop> GetWorkShopById(Guid workShopId)
        {
            var workshop = await _context.Workshop.FindAsync(workShopId);
            if (workshop != null)
            {
                return workshop;
            }
            return null;
        }
    }
}
