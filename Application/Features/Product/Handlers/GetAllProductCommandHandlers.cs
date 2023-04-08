using Application.Features.Product.Queries.Request;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Handlers
{
    public class GetAllProductCommandHandlers : IRequestHandler<GetAllProductQuery, bool>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductCommandHandlers(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {

            var dapperQuery = await _productRepository.ExecuteAsync("Select * from Products");

           // var efQuery = await _productRepository.GetListAsync();

            return true;
        }


    }
    
}


 
