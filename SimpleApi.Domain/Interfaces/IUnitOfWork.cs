using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApi.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        int Complete();
    }
}
