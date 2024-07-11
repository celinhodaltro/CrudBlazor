using System;
using System.Collections.Generic;
using System.Entities;
using System.Linq;
using System.Provider;
using System.Text;
using System.Threading.Tasks;

namespace System.BusinessRules
{
    public class ProductBusinessRules
    {
        private readonly DefaultProvider _defaultProvider;

        public ProductBusinessRules(DefaultProvider defaultProvider)
        {
            _defaultProvider = defaultProvider;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _defaultProvider.GetAsync<Product>(id);
            if (product == null)
            {
                throw new Exception("Product not found!");
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _defaultProvider.GetAllAsync<Product>();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {          
            
            Validate(product);

            return await _defaultProvider.CreateAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            product.Validate();
            return await _defaultProvider.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _defaultProvider.DeleteAsync<Product>(id);
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            await _defaultProvider.SoftDeleteAsync<Product>(id);
        }

        private bool Validate(Product product)
        {
            if (!product.Validate())
                throw new Exception("Invalid Product");
            else 
                return true;
        }
    }
}
