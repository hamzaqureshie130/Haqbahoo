using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
    public interface IFeedbackRepository
    {
        Task<bool> AddFeedback(Feedback feedback);

        Task<IEnumerable<Feedback>> GetAllFeedback();
    }
}
