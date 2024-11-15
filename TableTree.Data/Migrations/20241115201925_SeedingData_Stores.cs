using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData_Stores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b5761c8-d569-45da-a565-872d1a169186"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("14676eed-6ac2-4d23-a695-862d410b2ba6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93c305c9-f0aa-45c7-9ef4-4947366f68b4"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("65c0c0ae-7321-422a-9f85-17197534a607"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("784f8f69-b29f-41bf-afe0-85b92b044324"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("a6474ea9-c5ed-467f-95a2-ee8b897e5972"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "Address" },
                values: new object[,]
                {
                    { new Guid("5f69b658-4422-4bb6-94b1-46a5f146f826"), "Bulgaria, Sofia, Druzhba" },
                    { new Guid("8e37d43e-cdc4-48ca-ade3-63147766cbce"), "Bulgaria, Bourgas, Trakiya" },
                    { new Guid("be64604e-12e3-4872-bd07-242f1e45d0f2"), "Bulgaria, Plovdiv, Trakiya" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65c0c0ae-7321-422a-9f85-17197534a607"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("784f8f69-b29f-41bf-afe0-85b92b044324"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a6474ea9-c5ed-467f-95a2-ee8b897e5972"));

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: new Guid("5f69b658-4422-4bb6-94b1-46a5f146f826"));

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: new Guid("8e37d43e-cdc4-48ca-ade3-63147766cbce"));

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: new Guid("be64604e-12e3-4872-bd07-242f1e45d0f2"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("0b5761c8-d569-45da-a565-872d1a169186"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("14676eed-6ac2-4d23-a695-862d410b2ba6"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("93c305c9-f0aa-45c7-9ef4-4947366f68b4"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });
        }
    }
}
