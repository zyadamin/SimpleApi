using SimpleApi.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.BLL.Service.Intrfaces
{
    public interface IOrderService
    {
        int CreateOrder(OrderModel order);
        void DeleteOrder(int id);
        OrderViewModel GetOrderById(int id);
        int ConfirmOrder(OrderInfo order);
    }
}
