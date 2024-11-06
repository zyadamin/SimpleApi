using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.BLL.Models
{
    public class OrderModel
    {

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string MobileNumber { get; set; }
        public string ShippingMethod { get; set; }
        public List<OrderItemModel> Items { get; set; }

    }
}
