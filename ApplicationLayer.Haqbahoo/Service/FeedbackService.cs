using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Service
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<bool> AddFeedback(Feedback feedback)
        {
            return await _feedbackRepository.AddFeedback(feedback);
        }

      
        public async Task<IEnumerable<Feedback>> GetAllFeedback()
        {
          return await _feedbackRepository.GetAllFeedback();
        }

    
    }
}
