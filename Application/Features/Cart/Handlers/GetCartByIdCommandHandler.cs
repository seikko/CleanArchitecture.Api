using Application.Features.Cart.Queries.Request;
using Application.Features.Cart.Queries.Response;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cart.Handlers
{
    public class GetCartByIdCommandHandler : IRequestHandler<GetCartByIdQuery, GetCartByIdResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartDetailRepository _cartDetailRepository;

        public GetCartByIdCommandHandler(ICartRepository cartRepository, ICartDetailRepository cartDetailRepository)
        {
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
        }

        public async Task<GetCartByIdResponse> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.CartId); 
            if (cart != null)
            {
                var cartDetail = await _cartDetailRepository.GetListAsync(k => k.CartId == cart.Id);
                if (cartDetail != null)
                {
                    return new GetCartByIdResponse()
                    {
                        CartId = cart.Id,
                        CustomerId = cart.CustomerId,
                        TotalAmount = cart.TotalAmount,
                        Items = cartDetail.ToList()
                    };
                }
                return new GetCartByIdResponse()
                {
                    CartId = cart.Id,
                    CustomerId = cart.CustomerId,
                    TotalAmount = cart.TotalAmount,
                    Items = null
                };
            }
            return null;

        }
    }
}
