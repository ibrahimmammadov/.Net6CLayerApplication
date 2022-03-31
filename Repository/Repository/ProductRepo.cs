using Core;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Product>> GetProductWithCateg()
        {
            return await _context.Products.Include(x=>x.Category).ToListAsync();

        }
    }
}
