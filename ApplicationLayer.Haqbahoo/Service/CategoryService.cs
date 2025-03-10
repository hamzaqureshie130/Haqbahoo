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
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddCategory(Category category)
        {
            return await _categoryRepository.AddCategory(category);
        }

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            return await _categoryRepository.DeleteCategory(categoryId);
        }

        public async Task<bool> EditCategory(Category category)
        {
            return await _categoryRepository.EditCategory(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
          return await _categoryRepository.GetAllCategory();
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            return await _categoryRepository.GetCategoryById(categoryId);
        }
    }
}
