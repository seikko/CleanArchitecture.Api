using Application.Features.Cart.Commands.Request;
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
    public class DeleteCartByIdCommandHandler : IRequestHandler<DeleteCartCommandRequest, bool>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartDetailRepository _cartDetailRepository;

        public DeleteCartByIdCommandHandler(ICartRepository cartRepository, ICartDetailRepository cartDetailRepository)
        {
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
        }

        public async Task<bool> Handle(DeleteCartCommandRequest request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.CartId);
            if (cart == null) return false;
            var cartDetail = await _cartDetailRepository.GetListAsync(x => x.CartId == cart.Id);
            if (cartDetail == null) return false;
            _cartRepository.Delete(cart.Id);
            await _cartRepository.SaveChangeAsync();
            foreach (var item in cartDetail)
            {
                _cartDetailRepository.Delete(item.Id);
            }
            await _cartDetailRepository.SaveChangeAsync();
            return true;

        }
    }
}
