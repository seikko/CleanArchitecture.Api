using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CartDetailRepository: BaseRepository<CartDetail>, ICartDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public CartDetailRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
