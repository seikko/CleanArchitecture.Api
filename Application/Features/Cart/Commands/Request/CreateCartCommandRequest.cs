using Application.Features.Cart.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cart.Commands.Request
{
    public class CreateCartCommandRequest:IRequest<CreateCartCommandResponse>
    {
        public Guid CartId { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
