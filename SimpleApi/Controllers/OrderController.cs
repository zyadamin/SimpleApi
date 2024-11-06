using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.BLL.Models;
using SimpleApi.BLL.Service;
using SimpleApi.BLL.Service.Intrfaces;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderModel order)
        {
            try
            {
                if (order == null || !order.Items.Any())
                    return BadRequest("Order must contain at least one item.");
                
               var result= _orderService.CreateOrder(order);

                if (result > 0)
                {
                    return Ok("Order Submited successfully");
                }
                else {
                    return BadRequest("Order exceed limits");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpPost]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return Ok("Order Deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpPost]
        public IActionResult GetOrder(int id)
        {
            try
            {
                return Ok(_orderService.GetOrderById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
