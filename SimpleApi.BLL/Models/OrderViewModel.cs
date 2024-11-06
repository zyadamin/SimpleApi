using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.BLL.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string MobileNumber { get; set; }
        public int StatusId { get; set; }
        public double TotalAmount { get; set; }
        public string ShippingMethod { get; set; }
        public  List<OrderItemViewModel> Items { get; set; }
    }
}
