using Application.Features.Cart.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cart.Queries.Request
{
    public class GetCartByIdQuery:IRequest<GetCartByIdResponse>
    {
        public Guid CartId { get; set; }
    }
}
