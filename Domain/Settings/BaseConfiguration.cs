using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Settings
{
    public abstract  class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual  void Configure(EntityTypeBuilder<T> builder)
        {

            builder.Property(k => k.Id).HasColumnName("Id");
            builder.Property(k => k.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(k => k.ModifiedOn).HasColumnName("ModifiedOn");
        }
    }
}
