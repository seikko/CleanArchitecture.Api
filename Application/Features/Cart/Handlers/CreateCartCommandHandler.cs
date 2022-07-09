using Application.Features.Cart.Commands.Request;
using Application.Features.Cart.Commands.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cart.Handlers
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommandRequest, CreateCartCommandResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartDetailRepository _cartDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateCartCommandHandler(ICartRepository cartRepository, IProductRepository productRepository, ICartDetailRepository cartDetailRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateCartCommandResponse> Handle(CreateCartCommandRequest request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.CartId);
            if (cart == null)
            {
                cart = new Domain.Entities.Cart()
                {
                    CreatedOn = DateTime.Now,
                    CustomerId = request.CustomerId,
                    TotalAmount = 0,
                };
                await _cartRepository.AddAsync(cart);
                var price = await _productRepository.GetAsync(x => x.Id == request.ProductId, x => new { x.Price });
                var cartDetail = new Domain.Entities.CartDetail()
                {
                    ProductId = request.ProductId,
                    Price = price.Price,
                    CartId = cart.Id,
                    CreatedOn = DateTime.Now,
                    Quantity = request.Quantity,
                };
                await _cartDetailRepository.AddAsync(cartDetail);
                await _cartRepository.SaveChangeAsync();

                CalculationCart(cart, cartDetail);
                return _mapper.Map<CreateCartCommandResponse>(cart);
            }
            else
            {
                var cartDetail = await _cartDetailRepository.GetListAsync(x => x.CartId == request.CartId);
                if (cartDetail != null)
                {
                    var product = cartDetail.Where(x => x.ProductId == request.ProductId).FirstOrDefault();
                    if (product != null)
                    {
                        product.Quantity = request.Quantity;
                        _cartDetailRepository.Update(product);
                       await _cartDetailRepository.SaveChangeAsync();
                        CalculationCart(cart, product);
                        return _mapper.Map<CreateCartCommandResponse>(cart);

                    }
                }
                return null;

            }
        }
        private async void CalculationCart(Domain.Entities.Cart cart, CartDetail detail)
        {
            cart.TotalAmount = detail.Quantity * detail.Price;
            _cartRepository.Update(cart);
            await _cartRepository.SaveChangeAsync();
            await _cartDetailRepository.SaveChangeAsync();

        }
    }
}
