using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5268), "Cpu", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5278), "Motherboard", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5280), "Graphic Card", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5782), "Msi B550 TomoHawk", 150m, 41, null },
                    { 2, 2, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5785), "Gigabyte 560M Aorus Elite", 150m, 41, null },
                    { 3, 2, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5787), "Asrock X570 Aqua", 354m, 5, null },
                    { 4, 2, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5787), "Asus Rog Series B450", 280m, 35, null },
                    { 5, 3, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5789), "Nvidia RTX 3060 Ti FE", 399m, 260, null },
                    { 6, 3, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5792), "XFX 6700XT SpeedSter", 580m, 33, null },
                    { 7, 3, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5794), "PowerColor 6800XT Red Devil", 980m, 30, null },
                    { 8, 1, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5794), "Intel i7 12700KF", 350m, 3000, null },
                    { 9, 1, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5797), "AMD Ryzen Threadripper PRO 3995", 6700m, 199, null },
                    { 10, 1, new DateTime(2022, 3, 23, 6, 7, 9, 61, DateTimeKind.Local).AddTicks(5797), "AMD Ryzen 5600X", 299m, 1200, null }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 1, "Brown", 100, 1, 150 });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 2, "Blue", 100, 2, 150 });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 3, "Grey", 100, 3, 150 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
