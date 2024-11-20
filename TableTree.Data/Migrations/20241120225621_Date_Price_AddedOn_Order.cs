using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class Date_Price_AddedOn_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

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
    }
}
