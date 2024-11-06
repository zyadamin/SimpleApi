using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string MobileNumber { get; set; }
        public int StatusId { get; set; }      
        public double TotalAmount { get; set; }    
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public string ShippingMethod { get; set; } 

        public OrderStatus OrderStatus { get; set; }  
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
