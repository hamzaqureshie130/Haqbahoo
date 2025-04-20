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
    public class DashboardRepository:IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<Dashboard> GetDashboard()
        {
            var dashboard = new Dashboard()
            {
                TotalCars = await _context.Cars.CountAsync(),
                TotalActiveCar = await _context.Cars.Where(x => x.Status == false).CountAsync(),
                TotalInactiveCar = await _context.Cars.Where(x => x.Status == true).CountAsync(),


            };
            return dashboard;
        }
    }
}
