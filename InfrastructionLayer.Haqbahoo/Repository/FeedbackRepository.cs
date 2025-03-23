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
   public class FeedbackRepository:IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;
        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFeedback(Feedback feedback)
        {
            await _context.Feedback.AddAsync(feedback);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedback()
        {
            return await _context.Feedback.ToListAsync();
        }
    }
}
