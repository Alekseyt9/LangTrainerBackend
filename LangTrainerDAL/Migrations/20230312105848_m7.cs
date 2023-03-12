using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PartOfSpeech",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[,]
                {
                    { new Guid("3ec5b5bb-baed-4135-853e-23cbf14cea68"), new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "adjective" },
                    { new Guid("4b8b1b37-2696-466b-a053-c5a2f4f5c1a3"), new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "noun" },
                    { new Guid("571a9fdb-f2db-4e55-acaf-3670db7153eb"), new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "interjection" },
                    { new Guid("8f281ed9-fb46-49c4-88c7-0c00d304b2cb"), new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "pronoun" },
                    { new Guid("b78304b8-70fa-475c-8898-a7d5c8f48a66"), new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "adverb" },
                    { new Guid("ca7cf798-0015-42b1-bf47-d450da865b75"), new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "preposition" },
                    { new Guid("eea3308f-90eb-43de-815f-15f3b3dc8a22"), new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "conjunction" },
                    { new Guid("fd0049c4-f203-44bf-ae8c-1679a81de1d4"), new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "verb" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 197, 9, 49, 243, 213, 215, 45, 163, 98, 2, 27, 10, 165, 177, 209, 11, 94, 124, 40, 88, 7, 224, 3, 227, 242, 152, 235, 37, 207, 217, 130, 208, 86, 239, 185, 147, 76, 12, 121, 50, 63, 165, 231, 173, 162, 105, 177, 20, 148, 141, 40, 64, 105, 229, 165, 106, 223, 16, 21, 52, 130, 26, 74, 24 }, "057F246B8A85F9F668C80602BF05DA0E984C2C859D550B78556976780B431474DB0F9D18D564E2367078FAEECCFFFE0AF6632F6381EEDAC5E044969A77401A2D" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PartOfSpeech",
                keyColumn: "Id",
                keyValue: new Guid("3ec5b5bb-baed-4135-853e-23cbf14cea68"));

            migrationBuilder.DeleteData(
                table: "PartOfSpeech",
                keyColumn: "Id",
                keyValue: new Guid("4b8b1b37-2696-466b-a053-c5a2f4f5c1a3"));

            migrationBuilder.DeleteData(
                table: "PartOfSpeech",
                keyColumn: "Id",
                keyValue: new Guid("571a9fdb-f2db-4e55-acaf-3670db7153eb"));

            migrationBuilder.DeleteData(
                table: "PartOfSpeech",
                keyColumn: "Id",
                keyValue: new Guid("8f281ed9-fb46-49c4-88c7-0c00d304b2cb"));

            migrationBuilder.DeleteData(
                table: "PartOfSpeech",
                keyColumn: "Id",
                keyValue: new Guid("b78304b8-70fa-475c-8898-a7d5c8f48a66"));

            migrationBuilder.DeleteData(
                table: "PartOfSpeech",
                keyColumn: "Id",
                keyValue: new Guid("ca7cf798-0015-42b1-bf47-d450da865b75"));

            migrationBuilder.DeleteData(
                table: "PartOfSpeech",
                keyColumn: "Id",
                keyValue: new Guid("eea3308f-90eb-43de-815f-15f3b3dc8a22"));

            migrationBuilder.DeleteData(
                table: "PartOfSpeech",
                keyColumn: "Id",
                keyValue: new Guid("fd0049c4-f203-44bf-ae8c-1679a81de1d4"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 170, 78, 229, 123, 3, 101, 81, 213, 56, 79, 84, 232, 27, 240, 71, 183, 54, 74, 9, 43, 96, 3, 151, 222, 159, 115, 237, 43, 115, 143, 239, 177, 117, 86, 1, 222, 235, 140, 169, 181, 54, 95, 133, 12, 58, 199, 67, 25, 239, 124, 64, 9, 9, 125, 87, 253, 110, 21, 12, 100, 106, 70, 193, 102 }, "551466C676AD62E66F82C26B7A87A75632B9E0181839649023A3F37D6BB2AF761851DC0CF837FB15C8BEC2E4686BE7FE8E7AE6CDB361FD1FF495C83FD11C4EC7" });
        }
    }
}
