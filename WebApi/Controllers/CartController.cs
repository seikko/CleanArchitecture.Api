using Application.Features.Cart.Commands.Request;
using Application.Features.Cart.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromQuery] CreateCartCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet("getCartById")]
        public async Task<IActionResult> GetCartById(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            return Ok(await _mediator.Send(new GetCartByIdQuery { CartId = id }));
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteCartById(Guid id)
        {
            if(id == Guid.Empty) return BadRequest();
            return Ok(await _mediator.Send(new DeleteCartCommandRequest { CartId = id }));
        }


    }
}
