using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class TreeType_Data_Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TypeOfTrees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766"), "Beech" },
                    { new Guid("401dd5cd-c271-4960-84ce-0b364c96f039"), "Оак" },
                    { new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34"), "Tree" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeOfTrees",
                keyColumn: "Id",
                keyValue: new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766"));

            migrationBuilder.DeleteData(
                table: "TypeOfTrees",
                keyColumn: "Id",
                keyValue: new Guid("401dd5cd-c271-4960-84ce-0b364c96f039"));

            migrationBuilder.DeleteData(
                table: "TypeOfTrees",
                keyColumn: "Id",
                keyValue: new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34"));
        }
    }
}
