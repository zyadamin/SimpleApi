using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.BLL.Models
{
    public class OrderInfo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(500)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(12)]
        public string MobileNumber { get; set; }

    }
}
