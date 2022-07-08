using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Settings
{
    public class CartDetailSettings:BaseConfiguration<CartDetail>
    {
        public override void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            base.Configure(builder);
        }
    }
}
