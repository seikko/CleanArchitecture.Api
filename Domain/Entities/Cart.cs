using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart:BaseEntity
    {
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartDetail>? Items { get; set; }
    }
}
