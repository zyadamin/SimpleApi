using SimpleApi.BLL.Models;
using SimpleApi.DAL.Context;
using SimpleApi.Domain.Entity;
using SimpleApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleApi.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> ListProducts(int start, int size)
        {
            return _context.Products.Skip(start)?.Take(size)?.ToList();
        }
    }
}
