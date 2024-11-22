using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderItem_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("485f4682-fbc8-4eae-916e-3780f82400c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1995219-4a4b-423a-b79a-c63d86c76642"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a27b9c43-f0b8-4423-8f52-d46b8f7e1fb6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb93b61a-0562-4a0d-bbda-560d12110a3b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e099d1d5-56f3-4812-990f-831730848dc9"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "OrderItemInfo",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemInfo", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItemInfo_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemInfo_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("54144438-5bc3-4134-a519-f60e9b7ab8f7"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("b4ac4cb5-a528-4c95-8bc2-1eaa78f380ec"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("b9a313ca-776a-41df-90bd-b5ad9851a338"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("c162c79c-bca5-441e-9cde-1487cdac45bf"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("d457edc0-5dd4-484d-b17b-ef7f184af83e"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemInfo_ProductId",
                table: "OrderItemInfo",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemInfo");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54144438-5bc3-4134-a519-f60e9b7ab8f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4ac4cb5-a528-4c95-8bc2-1eaa78f380ec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9a313ca-776a-41df-90bd-b5ad9851a338"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c162c79c-bca5-441e-9cde-1487cdac45bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d457edc0-5dd4-484d-b17b-ef7f184af83e"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "OrderId", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("485f4682-fbc8-4eae-916e-3780f82400c8"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", null, 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("a1995219-4a4b-423a-b79a-c63d86c76642"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", null, 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("a27b9c43-f0b8-4423-8f52-d46b8f7e1fb6"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", null, 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("bb93b61a-0562-4a0d-bbda-560d12110a3b"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpg", false, "Rustic Live Edge Tree Table", null, 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("e099d1d5-56f3-4812-990f-831730848dc9"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", null, 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
