using SimpleApi.BLL.Models;
using SimpleApi.BLL.Service.Intrfaces;
using SimpleApi.Domain.Entity;
using SimpleApi.Domain.Enum;
using SimpleApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.BLL.Service
{
    public class OrderService : IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateOrder(OrderModel order)
        {
            var result = 0;
            double totalAmount = 0;
            List<OrderItem> items = new List<OrderItem>();

            foreach (var item in order.Items) { 
            
                Product product = _unitOfWork.Products.GetById(item.ProductId);

                if (item.Quantity >= product.QuantityInStock) {
                    return result;
                }

                OrderItem orderItem = new OrderItem() { 
               
                    ProductId = item.ProductId,
                    UnitPrice=product.Price,
                    Quantity = item.Quantity,
                    TotalPrice = product.Price * item.Quantity
                };
                totalAmount += orderItem.TotalPrice;
                items.Add(orderItem);
            }
            Order submitedOrder = new Order()
            {
                OrderItems = items,
                MobileNumber = order.MobileNumber,
                CustomerAddress = order.CustomerAddress,
                CustomerName = order.CustomerName,
                StatusId = (int)Status.Pending,
                ShippingMethod = order.ShippingMethod,
                TotalAmount = totalAmount,
            };

             result = _unitOfWork.Orders.Add(submitedOrder).Id;
            _unitOfWork.Complete();

            return result;

        }

        public void DeleteOrder(int id)
        {
            Order order = _unitOfWork.Orders.GetById(id);
            _unitOfWork.Orders.Delete(order);
            _unitOfWork.Complete();
        }

        public OrderViewModel GetOrderById(int id)
        {
           Order order = _unitOfWork.Orders.GetOrderById(id);
            var orderViewModel = new OrderViewModel
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                CustomerAddress = order.CustomerAddress,
                MobileNumber = order.MobileNumber,
                StatusId = order.StatusId,
                TotalAmount = order.TotalAmount,
                ShippingMethod = order.ShippingMethod,
                Items = order.OrderItems.Select(item => new OrderItemViewModel
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };
            return orderViewModel;
        }
    }
}
