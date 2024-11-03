using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductClient_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Categories_CategoryId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_TreeType_TreeTypeId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreeType",
                table: "TreeType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "TreeType",
                newName: "TypeOfTrees");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_TreeTypeId",
                table: "Products",
                newName: "IX_Products_TreeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfTrees",
                table: "TypeOfTrees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductsClients",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsClients", x => new { x.ProductId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ProductsClients_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsClients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsClients_ApplicationUserId",
                table: "ProductsClients",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypeOfTrees_TreeTypeId",
                table: "Products",
                column: "TreeTypeId",
                principalTable: "TypeOfTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypeOfTrees_TreeTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductsClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfTrees",
                table: "TypeOfTrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "TypeOfTrees",
                newName: "TreeType");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Tables");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TreeTypeId",
                table: "Tables",
                newName: "IX_Tables_TreeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Tables",
                newName: "IX_Tables_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreeType",
                table: "TreeType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Categories_CategoryId",
                table: "Tables",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_TreeType_TreeTypeId",
                table: "Tables",
                column: "TreeTypeId",
                principalTable: "TreeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
