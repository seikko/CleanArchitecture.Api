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
    public class CartSettings: BaseConfiguration<Cart>
    {
        public override void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts").HasKey(k => k.Id); 
            builder.Property(k => k.TotalAmount).HasColumnName("TotalAmount");
            builder.Property(k => k.CustomerId).HasColumnName("CustomerId"); 
        }
    }
}
