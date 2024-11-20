using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class SequenceNumber_OnOrder_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "SequenceNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "OrderId", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("5ddd4423-e07b-4e7a-a30a-a27bc8b347aa"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", null, 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("7195396d-120d-4146-9d36-efe7285cc919"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", null, 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("775c2b41-48be-49b5-b9ae-99ce3d6a4a1e"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", null, 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("9161788f-7154-4595-8cd6-786c1ace90b5"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpg", false, "Rustic Live Edge Tree Table", null, 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("b88d9100-5f29-4df0-9a84-17fcc9705c00"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", null, 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ddd4423-e07b-4e7a-a30a-a27bc8b347aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7195396d-120d-4146-9d36-efe7285cc919"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("775c2b41-48be-49b5-b9ae-99ce3d6a4a1e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9161788f-7154-4595-8cd6-786c1ace90b5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b88d9100-5f29-4df0-9a84-17fcc9705c00"));

            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "Orders");

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
        }
    }
}
