using Application.Features.Product.Queries.Request;
using Application.Features.Product.Queries.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Handlers
{
    public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async  Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        { 
            if(request.Id == Guid.Empty) return null;
            var product = await _productRepository.GetAsync<Domain.Entities.Product>("Select * from Products with (nolock) where Id = @p1",new { p1 = request.Id});
            if(product == null) return null;
            return _mapper.Map<GetProductByIdQueryResponse>(product);
            
        }
    }
}
