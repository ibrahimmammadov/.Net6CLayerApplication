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
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, Name ="Msi B550 TomoHawk", Price =150, Stock=41, CategoryId =2, CreatedDate = DateTime.Now },
                new Product { Id = 2, Name = "Gigabyte 560M Aorus Elite", Price = 150, Stock = 41, CategoryId = 2, CreatedDate = DateTime.Now },
                new Product { Id = 3, Name = "Asrock X570 Aqua", Price = 354, Stock = 5, CategoryId = 2, CreatedDate = DateTime.Now },
                new Product { Id = 4, Name = "Asus Rog Series B450", Price = 280, Stock = 35, CategoryId = 2, CreatedDate = DateTime.Now },
                new Product { Id = 5, Name = "Nvidia RTX 3060 Ti FE", Price = 399, Stock = 260, CategoryId = 3, CreatedDate = DateTime.Now },
                new Product { Id = 6, Name = "XFX 6700XT SpeedSter", Price = 580, Stock = 33, CategoryId = 3, CreatedDate = DateTime.Now },
                new Product { Id = 7, Name = "PowerColor 6800XT Red Devil", Price = 980, Stock = 30, CategoryId = 3, CreatedDate = DateTime.Now },
                new Product { Id = 8, Name = "Intel i7 12700KF", Price = 350, Stock = 3000, CategoryId = 1, CreatedDate = DateTime.Now },
                new Product { Id = 9, Name = "AMD Ryzen Threadripper PRO 3995", Price = 6700, Stock = 199, CategoryId = 1, CreatedDate = DateTime.Now },
                new Product { Id = 10, Name = "AMD Ryzen 5600X", Price = 299, Stock = 1200, CategoryId = 1, CreatedDate = DateTime.Now });
        }
    }
}
