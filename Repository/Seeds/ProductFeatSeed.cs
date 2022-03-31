using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seeds
{
    internal class ProductFeatSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(new ProductFeature { Id = 1, Color = "Brown", Height = 100, Width = 150, ProductId = 1 },
                new ProductFeature { Id = 2, Color = "Blue", Height = 100, Width = 150, ProductId = 2 },
                new ProductFeature { Id = 3, Color = "Grey", Height = 100, Width = 150, ProductId = 3 });
        }
    }
}
