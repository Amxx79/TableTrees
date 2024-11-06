using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class Category_Data_Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "Bathroom Countertop" },
                    { new Guid("6acd5822-a59e-4427-b8ac-fbca0751cd98"), "Mirrors" },
                    { new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Table" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6acd5822-a59e-4427-b8ac-fbca0751cd98"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"));
        }
    }
}
