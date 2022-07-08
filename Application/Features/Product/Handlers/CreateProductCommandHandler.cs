using Application.Features.Product.Commands.Request;
using Application.Features.Product.Commands.Response;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var product = _mapper.Map<Domain.Entities.Product>(request);
                await _productRepository.AddAsync(product);
                return new CreateProductCommandResponse()
                {
                    Description = product.Description ?? "",
                    Id = product.Id,
                    Price = product.Price,
                    ProductName = product.ProductName ??""
                };
            }
            return null;
        }
        public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
        {
            public CreateProductCommandValidator()
            {
                RuleFor(x=> x.ProductName).NotEmpty();
                RuleFor(x => x.Price).Equal(0);
                RuleFor(x => x.Description).MinimumLength(2);
            }
        }
    }
}
