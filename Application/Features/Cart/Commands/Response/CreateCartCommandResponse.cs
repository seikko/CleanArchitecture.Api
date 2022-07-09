using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cart.Commands.Response
{
    public class CreateCartCommandResponse
    {
        public Guid CartId { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }

    }
}
