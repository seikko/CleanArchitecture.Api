using Application.Features.Product.Commands.Request;
using Application.Features.Product.Commands.Response;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                //var product = await _productRepository.GetAsync(x=> x.Id == request.Id);
                //var product = await _productRepository.GetAsync<Product>("Select * from Products where id = @p1",new { p1 = request.Id});
                //var product = await _productRepository.GetAsync(x => x.Id == request.Id, x => new { x.Id });
                //var product = await _productRepository.GetAsync<Product>("Select * from Products where id = @p1",new { p1 = request.Id}, x=> new {x.Id});
                if (product != null)
                {
                    product.ProductName = request.ProductName;
                    product.Price = request.Price;
                    product.Description = request.Description;
                    _productRepository.Update(product);
                    return _mapper.Map<UpdateProductCommandResponse>(request);
                }
            }
            return null;
        }
        public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
        {
            public UpdateProductCommandValidator()
            {
                RuleFor(x => x.ProductName).NotEmpty();
                RuleFor(x => x.Price).Equal(0);
                RuleFor(x => x.Description).MinimumLength(2);
            }
        }
    }
}
