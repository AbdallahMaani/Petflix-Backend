using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullPetflix.Models;
using FullPetflix.ProductFiles;

namespace FullPetflix.ProductFiles
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                throw;
            }
        }

        public async Task<Product> GetProductById(int productId)
        {
            try
            {
                return await _context.Products.FindAsync(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product {productId}: {ex.Message}");
                throw;
            }
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                product.ItemType = "Product"; // Ensure ItemType is set
                var result = await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                throw;
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = await _context.Products.FindAsync(product.product_id);
                if (existingProduct == null) return null;

                existingProduct.ItemType = product.ItemType;
                existingProduct.product_title = product.product_title;
                existingProduct.product_description = product.product_description;
                existingProduct.product_category = product.product_category;
                existingProduct.product_type = product.product_type;
                existingProduct.product_size = product.product_size;
                existingProduct.product_weight = product.product_weight;
                existingProduct.expiration = product.expiration;
                existingProduct.usage = product.usage;
                existingProduct.designedFor = product.designedFor;
                existingProduct.product_new_price = product.product_new_price;
                existingProduct.product_old_price = product.product_old_price;
                existingProduct.userId = product.userId;

                // Handle picture update - allow setting to null
                existingProduct.product_pic = string.IsNullOrEmpty(product.product_pic) ? null : product.product_pic;

                await _context.SaveChangesAsync();
                return existingProduct;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product {product.product_id}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                // First delete any favorites referencing this product
                var favorites = await _context.Favorites
                    .Where(f => f.ProductId == productId)
                    .ToListAsync();

                if (favorites.Any())
                {
                    _context.Favorites.RemoveRange(favorites);
                    await _context.SaveChangesAsync();
                }

                // Then delete the product
                var product = await _context.Products.FindAsync(productId);
                if (product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product {productId}: {ex.Message}");
                throw;
            }
        }
    }
}