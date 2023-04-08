using Application.Features.Product.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries.Request
{
    public class GetAllProductQuery: IRequest<bool>
    {
    }
}
