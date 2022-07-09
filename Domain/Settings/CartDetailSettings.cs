using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
            builder.ToTable("CartDetail").HasKey(k => k.Id); 
            builder.Property(k => k.ProductId).HasColumnName("ProductId");
            builder.Property(k => k.CartId).HasColumnName("CartId");
            builder.Property(k => k.Price).HasColumnName("Price");
            builder.Property(k => k.Quantity).HasColumnName("Quantity");
        }
    }
}
