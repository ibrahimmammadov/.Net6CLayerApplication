﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220323020709_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5268),
                            Name = "Cpu"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5278),
                            Name = "Motherboard"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5280),
                            Name = "Graphic Card"
                        });
                });

            modelBuilder.Entity("Core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5782),
                            Name = "Msi B550 TomoHawk",
                            Price = 150m,
                            Stock = 41
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5785),
                            Name = "Gigabyte 560M Aorus Elite",
                            Price = 150m,
                            Stock = 41
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5787),
                            Name = "Asrock X570 Aqua",
                            Price = 354m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5787),
                            Name = "Asus Rog Series B450",
                            Price = 280m,
                            Stock = 35
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5789),
                            Name = "Nvidia RTX 3060 Ti FE",
                            Price = 399m,
                            Stock = 260
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5792),
                            Name = "XFX 6700XT SpeedSter",
                            Price = 580m,
                            Stock = 33
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5794),
                            Name = "PowerColor 6800XT Red Devil",
                            Price = 980m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5794),
                            Name = "Intel i7 12700KF",
                            Price = 350m,
                            Stock = 3000
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5797),
                            Name = "AMD Ryzen Threadripper PRO 3995",
                            Price = 6700m,
                            Stock = 199
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5797),
                            Name = "AMD Ryzen 5600X",
                            Price = 299m,
                            Stock = 1200
                        });
                });

            modelBuilder.Entity("Core.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Brown",
                            Height = 100,
                            ProductId = 1,
                            Width = 150
                        },
                        new
                        {
                            Id = 2,
                            Color = "Blue",
                            Height = 100,
                            ProductId = 2,
                            Width = 150
                        },
                        new
                        {
                            Id = 3,
                            Color = "Grey",
                            Height = 100,
                            ProductId = 3,
                            Width = 150
                        });
                });

            modelBuilder.Entity("Core.Product", b =>
                {
                    b.HasOne("Core.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.ProductFeature", b =>
                {
                    b.HasOne("Core.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("Core.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Core.Product", b =>
                {
                    b.Navigation("ProductFeature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
