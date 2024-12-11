﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class Products_DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d6dcff4-261f-4d4c-886c-fa7516446857"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5fe45c7e-940c-4db9-93fc-6d711e246695"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73aed228-963b-4f4a-aaab-a5512e934e51"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7ef475d1-a272-4b52-bcb0-2343bd696a58"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd83f4c5-307e-449e-ae05-7c770a8e4113"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("2de3a6b8-7891-49c6-96ee-10a3b73d2f48"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("393006f7-9c37-4f7d-80c4-1db8c4ae7569"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("47ac7201-236d-42b2-91bd-b3f57d0bf77e"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpeg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") },
                    { new Guid("6cfa25f3-22a1-472d-89f2-e1d90fa124ef"), new Guid("6acd5822-a59e-4427-b8ac-fbca0751cd98"), "This special design, crafted from olive wood, has been meticulously prepared, preserving the natural edge and bark of the wood. The cracks have been filled with special epoxy, and a custom matte varnish has been applied to the wood surface to provide resistance against scratches without losing its natural texture", "/images/mirror-2.jpg", false, "Olive Wooden Wall Mirror, Wooden Mirror", 115.99m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("8bbd0d28-418d-40dc-b311-f254c29c1165"), new Guid("6acd5822-a59e-4427-b8ac-fbca0751cd98"), "Adorn your living space with our exquisite Epoxy and Olive Wood Decorative Bathroom Mirror – a fusion of artistry and practicality that transcends ordinary decor. Crafted with meticulous attention to detail, this handmade masterpiece is more than just a mirror", "/images/mirror-1.jpg", false, "Custom Epoxy and Olive Wood Decorative Mirror", 99.99m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("b29522fe-0ea0-4a01-9513-ab5d9cab230b"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("cc1f88fd-382d-4003-85e9-2d831d87406b"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("db8be300-48be-4da7-85cd-3402c40882be"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "Elevate your bathroom with our handcrafted wooden countertop, made from sustainably sourced oak. Each piece is carefully treated for durability, offering a unique blend of natural beauty and modern functionality to complement any decor style.", "/images/bathroom-countertop-1.jpg", false, "Wooden bathroom countertop", 235.99m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("e45a4684-87bc-49f4-846d-79c569a8520b"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "Transform your bathroom with this set of boutique natural wood countertops, expertly crafted from premium, sustainably sourced wood.", "/images/bathroom-countertop-2.jpg", false, "A set of boutique natural wood bathroom countertops", 199.00m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2de3a6b8-7891-49c6-96ee-10a3b73d2f48"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("393006f7-9c37-4f7d-80c4-1db8c4ae7569"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("47ac7201-236d-42b2-91bd-b3f57d0bf77e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6cfa25f3-22a1-472d-89f2-e1d90fa124ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8bbd0d28-418d-40dc-b311-f254c29c1165"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b29522fe-0ea0-4a01-9513-ab5d9cab230b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cc1f88fd-382d-4003-85e9-2d831d87406b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db8be300-48be-4da7-85cd-3402c40882be"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e45a4684-87bc-49f4-846d-79c569a8520b"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsDeleted", "Name", "Price", "TreeTypeId" },
                values: new object[,]
                {
                    { new Guid("0d6dcff4-261f-4d4c-886c-fa7516446857"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-3.jpg", false, "Epoxy resin table olive tree", 1200.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("5fe45c7e-940c-4db9-93fc-6d711e246695"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A unique epoxy resin table made from an olive tree. This coffee table was cast with turquoise semi-transparent epoxy resin and a touch of metallic powder, creating a beautiful turquoise water look. The fashionable stainless steel spider table frame completes the overall look of this coffee table.", "/images/table-2.jpeg", false, "Eris Hackberry Blue Epoxy Resin Table", 4800.00m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("73aed228-963b-4f4a-aaab-a5512e934e51"), new Guid("61bc3294-73ca-441b-9b53-0d4f26b673f3"), "A sturdy coffee table made from reclaimed pine with a rich, warm finish. Eco-friendly and unique, it brings warmth to any room.", "/images/table-1.jpeg", false, "Reclaimed Wood Counter Top", 450.00m, new Guid("401dd5cd-c271-4960-84ce-0b364c96f039") },
                    { new Guid("7ef475d1-a272-4b52-bcb0-2343bd696a58"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "Beautiful table featuring a blue resin river down the center, crafted from black walnut wood. Ideal for dining rooms.", "/images/table-4.jpeg", false, "Epoxy Resin River Table", 1199.50m, new Guid("133a6af3-1b7d-4d6e-aa41-33be63184766") },
                    { new Guid("dd83f4c5-307e-449e-ae05-7c770a8e4113"), new Guid("a1042fee-f95a-4bf3-a758-49b13cff3e79"), "A handcrafted table made from live-edge oak, showcasing natural wood grain and organic shape. Perfect as a centerpiece in any living space.", "/images/table-5.jpeg", false, "Rustic Live Edge Tree Table", 799.99m, new Guid("632bfa2f-aa06-4c1b-913d-33ef43a44d34") }
                });
        }
    }
}
