using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class AddingSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Supplier_SupplierId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "tblSuppliers");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "tblProducts");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "tblOrders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_SupplierId",
                table: "tblOrders",
                newName: "IX_tblOrders_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ProductId",
                table: "tblOrders",
                newName: "IX_tblOrders_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblSuppliers",
                table: "tblSuppliers",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProducts",
                table: "tblProducts",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOrders",
                table: "tblOrders",
                column: "OrderId");

            migrationBuilder.UpdateData(
                table: "tblOrders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "OrderDate", "TotalPrice" },
                values: new object[] { new DateTime(2022, 1, 6, 16, 15, 34, 757, DateTimeKind.Local).AddTicks(5037), 850.0 });

            migrationBuilder.UpdateData(
                table: "tblOrders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "OrderDate", "TotalPrice" },
                values: new object[] { new DateTime(2022, 1, 3, 16, 15, 34, 760, DateTimeKind.Local).AddTicks(5637), 450.0 });

            migrationBuilder.UpdateData(
                table: "tblOrders",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "OrderDate", "TotalPrice" },
                values: new object[] { new DateTime(2022, 1, 7, 16, 15, 34, 760, DateTimeKind.Local).AddTicks(5682), 150.0 });

            migrationBuilder.UpdateData(
                table: "tblOrders",
                keyColumn: "OrderId",
                keyValue: 4,
                columns: new[] { "OrderDate", "TotalPrice" },
                values: new object[] { new DateTime(2021, 12, 29, 16, 15, 34, 760, DateTimeKind.Local).AddTicks(5690), 390.0 });

            migrationBuilder.UpdateData(
                table: "tblProducts",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Photo",
                value: "/images/laptop.jpg");

            migrationBuilder.UpdateData(
                table: "tblProducts",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "Photo",
                value: "/images/book.png");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrders_tblProducts_ProductId",
                table: "tblOrders",
                column: "ProductId",
                principalTable: "tblProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrders_tblSuppliers_SupplierId",
                table: "tblOrders",
                column: "SupplierId",
                principalTable: "tblSuppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrders_tblProducts_ProductId",
                table: "tblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_tblOrders_tblSuppliers_SupplierId",
                table: "tblOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblSuppliers",
                table: "tblSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProducts",
                table: "tblProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOrders",
                table: "tblOrders");

            migrationBuilder.RenameTable(
                name: "tblSuppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "tblProducts",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "tblOrders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_tblOrders_SupplierId",
                table: "Order",
                newName: "IX_Order_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_tblOrders_ProductId",
                table: "Order",
                newName: "IX_Order_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "OrderDate", "TotalPrice" },
                values: new object[] { new DateTime(2022, 1, 6, 11, 30, 6, 926, DateTimeKind.Local).AddTicks(4484), 250.0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "OrderDate", "TotalPrice" },
                values: new object[] { new DateTime(2022, 1, 3, 11, 30, 6, 929, DateTimeKind.Local).AddTicks(9915), 250.0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "OrderDate", "TotalPrice" },
                values: new object[] { new DateTime(2022, 1, 7, 11, 30, 6, 929, DateTimeKind.Local).AddTicks(9967), 250.0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4,
                columns: new[] { "OrderDate", "TotalPrice" },
                values: new object[] { new DateTime(2021, 12, 29, 11, 30, 6, 929, DateTimeKind.Local).AddTicks(9975), 250.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Photo",
                value: "/images/laptop.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "Photo",
                value: "/images/book.jpg");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Supplier_SupplierId",
                table: "Order",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
