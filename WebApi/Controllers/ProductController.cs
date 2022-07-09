using Application.Features.Product.Commands.Request;
using Application.Features.Product.Queries.Request;
using Application.Features.Product.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("productId")]
        public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdQuery query)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery { Id = query.Id }));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductByIdCommandRequest request)
        {
            return Ok(await _mediator.Send(new DeleteProductByIdCommandRequest { Id = request.Id }));
        }
      
    }
}
