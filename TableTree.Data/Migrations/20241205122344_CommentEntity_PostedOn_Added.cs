﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommentEntity_PostedOn_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0be7bbcf-da14-428b-aea0-48aec315228f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("21cbfede-1e11-4173-b882-2adc36a6efc5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dded1b91-4163-432b-9f55-7145286d47dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6bfc23b-eb29-413a-a6ef-14d55098c65c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1546255-7389-42cd-9959-1868c097e118"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedOn",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("01447d8d-ddd4-4869-b933-65ccd3a46d59"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("60e3bd03-f484-4f34-bc11-c772b6ae47d1"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("8a19f4f0-d350-47d9-aca8-3100791bca54"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("d5f95acd-e469-4114-84c9-f214279e27ac"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("dd89b0b2-a258-410e-aab8-b139b74a872e"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("01447d8d-ddd4-4869-b933-65ccd3a46d59"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60e3bd03-f484-4f34-bc11-c772b6ae47d1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a19f4f0-d350-47d9-aca8-3100791bca54"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d5f95acd-e469-4114-84c9-f214279e27ac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd89b0b2-a258-410e-aab8-b139b74a872e"));

            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Comment");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("0be7bbcf-da14-428b-aea0-48aec315228f"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("21cbfede-1e11-4173-b882-2adc36a6efc5"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("dded1b91-4163-432b-9f55-7145286d47dd"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("e6bfc23b-eb29-413a-a6ef-14d55098c65c"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("f1546255-7389-42cd-9959-1868c097e118"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") }
                });
        }
    }
}