using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cart.Queries.Response
{
    public class GetCartByIdResponse
    {
        public Guid CartId { get; set; }
        public Guid  CustomerId{ get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartDetail> Items{ get; set; }
    }
}
