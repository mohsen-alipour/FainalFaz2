using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public byte StatusId { get; set; }
        public int Serviceid { get; set; }
        public int ServiceBasePrice { get; set; }
        public int CustomerUserId { get; set; }
        public int FainalExpertUserid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
