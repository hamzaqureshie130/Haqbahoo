using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.IRepository
{
   public interface ICategoryRepository
    {
        Task<bool> AddCategory(Category category);
        Task<bool> DeleteCategory(Guid categoryId);
        Task<bool> EditCategory(Category category);
        Task<Category> GetCategoryById(Guid categoryId);
        Task<IEnumerable<Category>> GetAllCategory();
    }
}
