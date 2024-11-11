using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.BLL.Models
{
    public class OrderModel
    {
        [Required]
        public List<OrderItemModel> Items { get; set; }

    }
}
