using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_Missed_DbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStore_Products_ProductId",
                table: "ProductStore");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStore_Store_StoreId",
                table: "ProductStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStore",
                table: "ProductStore");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1e868c51-bb80-4aab-a22c-3ee822554840"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ab3229e-d540-480c-b434-5d40f695b43e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d192712e-f5cc-4f2a-b5fb-f5c483bf69ac"));

            migrationBuilder.RenameTable(
                name: "ProductStore",
                newName: "Availability");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStore_StoreId",
                table: "Availability",
                newName: "IX_Availability_StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Availability",
                table: "Availability",
                columns: new[] { "ProductId", "StoreId" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("0b5761c8-d569-45da-a565-872d1a169186"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("14676eed-6ac2-4d23-a695-862d410b2ba6"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("93c305c9-f0aa-45c7-9ef4-4947366f68b4"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Products_ProductId",
                table: "Availability",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Store_StoreId",
                table: "Availability",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Products_ProductId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Store_StoreId",
                table: "Availability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Availability",
                table: "Availability");

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

            migrationBuilder.RenameTable(
                name: "Availability",
                newName: "ProductStore");

            migrationBuilder.RenameIndex(
                name: "IX_Availability_StoreId",
                table: "ProductStore",
                newName: "IX_ProductStore_StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStore",
                table: "ProductStore",
                columns: new[] { "ProductId", "StoreId" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("1e868c51-bb80-4aab-a22c-3ee822554840"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("4ab3229e-d540-480c-b434-5d40f695b43e"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("d192712e-f5cc-4f2a-b5fb-f5c483bf69ac"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStore_Products_ProductId",
                table: "ProductStore",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStore_Store_StoreId",
                table: "ProductStore",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
