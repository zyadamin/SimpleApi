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

            foreach (var item in order.Items)
            {

                Product product = _unitOfWork.Products.GetById(item.ProductId);

                if (item.Quantity >= product.QuantityInStock)
                {
                    return result;
                }

                OrderItem orderItem = new OrderItem()
                {

                    ProductId = item.ProductId,
                    UnitPrice = product.Price,
                    Quantity = item.Quantity,
                    TotalPrice = product.Price * item.Quantity
                };
                totalAmount += orderItem.TotalPrice;
                items.Add(orderItem);
            }
            Order submitedOrder = new Order()
            {
                OrderItems = items,
                StatusId = (int)Status.Pending,
                TotalAmount = totalAmount,
            };

            _unitOfWork.Orders.Add(submitedOrder);
            _unitOfWork.Complete();
            result = submitedOrder.Id;

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
            OrderViewModel orderViewModel = new OrderViewModel();
            if (order.StatusId == (int)Status.Pending) {

                 orderViewModel = new OrderViewModel
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
                        Quantity = item.Quantity,
                        TotalPrice = item.TotalPrice,
                        UnitPrice = item.UnitPrice,
                        Description = item.Product.Description,
                        Name = item.Product.Name,
                    }).ToList()
                };

            }

            return orderViewModel;
        }


        public int ConfirmOrder(OrderInfo orderInfo)
        {
            var result = 0;

            Order order = _unitOfWork.Orders.GetOrderById(orderInfo.Id);

            if (order != null)
            {
                order.StatusId = (int)Status.Shipped;
                order.CustomerAddress = orderInfo.CustomerAddress;
                order.MobileNumber = orderInfo.MobileNumber;
                order.CustomerName = orderInfo.CustomerName;
                _unitOfWork.Complete();
                result = orderInfo.Id;
            }
            return result;

        }

    }
}
