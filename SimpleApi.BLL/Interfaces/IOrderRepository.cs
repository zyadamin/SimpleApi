﻿using SimpleApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Domain.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Order GetOrderById(int id);

    }
}
