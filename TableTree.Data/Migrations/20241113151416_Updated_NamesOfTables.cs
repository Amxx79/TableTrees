using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updated_NamesOfTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProduct_AspNetUsers_ApplicationUserId",
                table: "FavouriteProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProduct_Products_ProductId",
                table: "FavouriteProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsClients_AspNetUsers_ApplicationUserId",
                table: "ProductsClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsClients_Products_ProductId",
                table: "ProductsClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsClients",
                table: "ProductsClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteProduct",
                table: "FavouriteProduct");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4dcbf9dd-9ec7-4352-bfc4-3d0824de0a63"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87fa072f-1f7a-4a84-9dc0-75dd1b399e15"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1d46565-7b6d-46a2-8535-c236b1abd1ab"));

            migrationBuilder.RenameTable(
                name: "ProductsClients",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "FavouriteProduct",
                newName: "FavouriteProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsClients_ApplicationUserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteProduct_ApplicationUserId",
                table: "FavouriteProducts",
                newName: "IX_FavouriteProducts_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                columns: new[] { "ProductId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteProducts",
                table: "FavouriteProducts",
                columns: new[] { "ProductId", "ApplicationUserId" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("4967f440-fae0-4651-9cc4-2ea712b97042"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("87d56e55-a204-4805-a5e1-4f2a26000900"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("bf9cfccc-0061-4286-8887-0322762ad351"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProducts_AspNetUsers_ApplicationUserId",
                table: "FavouriteProducts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProducts_Products_ProductId",
                table: "FavouriteProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProducts_AspNetUsers_ApplicationUserId",
                table: "FavouriteProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProducts_Products_ProductId",
                table: "FavouriteProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Products_ProductId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteProducts",
                table: "FavouriteProducts");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4967f440-fae0-4651-9cc4-2ea712b97042"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87d56e55-a204-4805-a5e1-4f2a26000900"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bf9cfccc-0061-4286-8887-0322762ad351"));

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ProductsClients");

            migrationBuilder.RenameTable(
                name: "FavouriteProducts",
                newName: "FavouriteProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ProductsClients",
                newName: "IX_ProductsClients_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteProducts_ApplicationUserId",
                table: "FavouriteProduct",
                newName: "IX_FavouriteProduct_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsClients",
                table: "ProductsClients",
                columns: new[] { "ProductId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteProduct",
                table: "FavouriteProduct",
                columns: new[] { "ProductId", "ApplicationUserId" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("4dcbf9dd-9ec7-4352-bfc4-3d0824de0a63"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "https://i.etsystatic.com/21622583/r/il/745996/5104378769/il_794xN.5104378769_dck9.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("87fa072f-1f7a-4a84-9dc0-75dd1b399e15"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "https://masivno.com/wp-content/uploads/2023/07/IMG_2392-1612x1655.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("f1d46565-7b6d-46a2-8535-c236b1abd1ab"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "https://theindustrialfurniture.co.uk/cdn/shop/files/EkranResmi2023-04-3011.47-PhotoRoom_grande.png?v=1692620377", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProduct_AspNetUsers_ApplicationUserId",
                table: "FavouriteProduct",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProduct_Products_ProductId",
                table: "FavouriteProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsClients_AspNetUsers_ApplicationUserId",
                table: "ProductsClients",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsClients_Products_ProductId",
                table: "ProductsClients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
