using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cart.Commands.Request
{
    public class DeleteCartCommandRequest:IRequest<bool>
    {
        public Guid CartId { get; set; }
    }
}
