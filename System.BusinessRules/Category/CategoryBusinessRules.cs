using System;
using System.Collections.Generic;
using System.Entities;
using System.Linq;
using System.Provider;
using System.Text;
using System.Threading.Tasks;

namespace System.BusinessRules
{
    public class CategoryBusinessRules
    {
        private readonly DefaultProvider _defaultProvider;

        public CategoryBusinessRules(DefaultProvider defaultProvider)
        {
            _defaultProvider = defaultProvider;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var Category = await _defaultProvider.GetAsync<Category>(id);
            if (Category == null)
            {
                throw new Exception("Category not found!");
            }

            return Category;
        }

        public async Task<IEnumerable<Category>> GetAllCategorysAsync()
        {
            return await _defaultProvider.GetAllAsync<Category>();
        }

        public async Task<Category> CreateCategoryAsync(Category Category)
        {          
            
            Validate(Category);

            return await _defaultProvider.CreateAsync(Category);
        }

        public async Task<Category> UpdateCategoryAsync(Category Category)
        {
            Category.Validate();
            return await _defaultProvider.UpdateAsync(Category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _defaultProvider.DeleteAsync<Category>(id);
        }

        public async Task SoftDeleteCategoryAsync(int id)
        {
            await _defaultProvider.SoftDeleteAsync<Category>(id);
        }

        private bool Validate(Category Category)
        {
            if (!Category.Validate())
                throw new Exception("Invalid Category");
            else 
                return true;
        }
    }
}
