using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding_NewProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("429117e1-d426-4707-bd5d-17cf642b413c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("972cfdf4-f9f5-4898-bfa6-398665260abe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7bb2f46-d6ba-470a-9b9f-4ddbbfb718e6"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("372e5ce5-0a53-4dff-8772-a031d57b62a3"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("5946e557-d2a0-43cd-b673-e26453a2b985"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("60e6bf1c-b320-4274-8fab-c0a35665e9d9"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-1.jpg", false, "Epoxy resin table olive tree", 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("7d16de69-c765-40d5-8a91-777b7526af6d"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("900b047a-f95e-4a4a-9bba-bf7a4dfe5f6f"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("372e5ce5-0a53-4dff-8772-a031d57b62a3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5946e557-d2a0-43cd-b673-e26453a2b985"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60e6bf1c-b320-4274-8fab-c0a35665e9d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d16de69-c765-40d5-8a91-777b7526af6d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("900b047a-f95e-4a4a-9bba-bf7a4dfe5f6f"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("429117e1-d426-4707-bd5d-17cf642b413c"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("972cfdf4-f9f5-4898-bfa6-398665260abe"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("b7bb2f46-d6ba-470a-9b9f-4ddbbfb718e6"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") }
                });
        }
    }
}
