using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PartOfSpeech",
                table: "Translate",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 79, 223, 227, 216, 147, 6, 131, 149, 196, 164, 65, 135, 161, 44, 65, 56, 202, 105, 7, 126, 55, 107, 49, 182, 194, 208, 210, 106, 102, 189, 25, 74, 42, 234, 111, 122, 26, 126, 16, 218, 121, 105, 26, 30, 193, 141, 20, 220, 197, 165, 223, 115, 105, 137, 86, 41, 183, 251, 58, 249, 255, 25, 145, 2 }, "DA8011B71FC59E71DAA35FE017C3A255446CACF4EBC74A416835E54F4326D8442DAF9D83840492449F40793087FD8E74C679238515E665F27FB9F83E0C179996" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PartOfSpeech",
                table: "Translate",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 158, 63, 197, 187, 226, 135, 142, 27, 69, 7, 9, 124, 64, 95, 78, 172, 36, 60, 124, 244, 239, 102, 207, 8, 230, 37, 63, 136, 160, 106, 5, 67, 190, 251, 10, 249, 232, 26, 136, 22, 43, 167, 237, 52, 55, 109, 113, 191, 78, 75, 151, 151, 175, 56, 25, 59, 93, 42, 217, 114, 242, 164, 100, 56 }, "67E3AF3B083DBD5B7943E0B6CEB2591A658A347509FD4572DBD400CC3C78BA4461FB8B49573C93EA1A86CBE7CD66B78447BAC357628F0AAEAF74B1FBF9AF5A24" });
        }
    }
}
