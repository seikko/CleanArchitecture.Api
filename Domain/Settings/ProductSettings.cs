using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Settings
{
    public class ProductSettings:BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product").HasKey(k => k.Id); 
            builder.Property(k => k.ProductName).HasColumnName("ProductName");
            builder.Property(k => k.Price).HasColumnName("Price");
            builder.Property(k => k.Description).HasColumnName("Description");
        }
    }
}
