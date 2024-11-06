
using SimpleApi.BLL.Models;
using SimpleApi.DAL.Context;
using SimpleApi.DAL.Repositories;
using SimpleApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);
        }

    public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
