using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
   public interface IFeedbackService
    {
        Task<bool> AddFeedback(Feedback feedback);
       
        Task<IEnumerable<Feedback>> GetAllFeedback();
    }
}
