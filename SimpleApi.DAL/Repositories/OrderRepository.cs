using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context= context;
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Where(x => x.Id == id)
                .Include(x => x.OrderItems)?.ThenInclude(x=>x.Product)
                .Include(x => x.OrderStatus).FirstOrDefault();
        }
    }
}
