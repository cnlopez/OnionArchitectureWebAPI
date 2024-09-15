using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddProductAsync(Product producto)
        {
            await _context.Products.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product producto)
        {
            _context.Products.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if (producto != null)
            {
                _context.Products.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
