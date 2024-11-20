using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class Order_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ac3d9b1-3177-4b2e-bb27-11791c1436a1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25d008be-1555-433e-a146-a72b85ae07ec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62d480d5-1459-453b-84e5-e54e36ed16a1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a9c418bc-f195-4398-b9e5-ef1c23072654"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f862983c-0b3c-421e-95dc-5397320ddd2a"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "OrderId", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("0b89f7bd-6706-45b6-a79b-6219ac270e07"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", null, 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("0faaddf1-6382-445a-b406-8ada6a968990"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", null, 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("4f488184-cb7e-4d35-8a20-07b52ca39c38"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", null, 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("c86e3be4-4884-4935-bfff-c3e0296fb42b"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpg", false, "Rustic Live Edge Tree Table", null, 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("ef81095b-3d4c-4826-ab9c-5177adc31026"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", null, 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b89f7bd-6706-45b6-a79b-6219ac270e07"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0faaddf1-6382-445a-b406-8ada6a968990"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4f488184-cb7e-4d35-8a20-07b52ca39c38"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c86e3be4-4884-4935-bfff-c3e0296fb42b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef81095b-3d4c-4826-ab9c-5177adc31026"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("0ac3d9b1-3177-4b2e-bb27-11791c1436a1"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("25d008be-1555-433e-a146-a72b85ae07ec"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("62d480d5-1459-453b-84e5-e54e36ed16a1"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("a9c418bc-f195-4398-b9e5-ef1c23072654"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("f862983c-0b3c-421e-95dc-5397320ddd2a"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });
        }
    }
}
