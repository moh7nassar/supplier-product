using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class CreateModDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvarchar40 = table.Column<string>(name: "nvarchar(40)", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvarchar40 = table.Column<string>(name: "nvarchar(40)", type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Photo", "Price", "nvarchar(40)" },
                values: new object[,]
                {
                    { 1, "/images/headphone.png", 200.0, "Headphones" },
                    { 2, "/images/laptop.png", 800.0, "Laptop" },
                    { 3, "/images/book.jpg", 30.0, "Book" }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "SupplierId", "Address", "Country", "Email", "nvarchar(40)", "Phone" },
                values: new object[,]
                {
                    { 1, "New York", "USA", "help@sony.com", "Sony", "0927420193" },
                    { 2, "Seoul", "Korea", "help@samsung.com", "Samsung", "0291728159" },
                    { 3, "Amman", "Jordan", "help@dna.com", "DNA", "0777777777" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "OrderDate", "ProductId", "Quantity", "Status", "SupplierId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 6, 11, 30, 6, 926, DateTimeKind.Local).AddTicks(4484), 1, 1, 0, 1, 250.0 },
                    { 4, new DateTime(2021, 12, 29, 11, 30, 6, 929, DateTimeKind.Local).AddTicks(9975), 2, 1, 3, 1, 250.0 },
                    { 2, new DateTime(2022, 1, 3, 11, 30, 6, 929, DateTimeKind.Local).AddTicks(9915), 2, 1, 2, 2, 250.0 },
                    { 3, new DateTime(2022, 1, 7, 11, 30, 6, 929, DateTimeKind.Local).AddTicks(9967), 3, 1, 1, 3, 250.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SupplierId",
                table: "Order",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
