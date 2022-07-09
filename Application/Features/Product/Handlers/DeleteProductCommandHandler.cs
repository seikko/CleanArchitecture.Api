using Application.Features.Product.Commands.Request;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Product.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductByIdCommandRequest, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductByIdCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                _productRepository.Delete(request.Id);
                await _productRepository.SaveChangeAsync();
                return true;
            }
            return false;
        }
    }
}
