using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Domain.Entity
{
    public class OrderItem
    {
        public int Id { get; set; }        
        public int OrderId { get; set; }            
        public int ProductId { get; set; }          
        public int Quantity { get; set; }           
        public double UnitPrice { get; set; }      
        public double TotalPrice { get; set; }     
        public Order Order { get; set; }           
        public Product Product { get; set; }
    }
}
