using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expressions_Text_PartOfSpeech_LanguageId",
                table: "Expressions");

            migrationBuilder.DropColumn(
                name: "PartOfSpeech",
                table: "Expressions");

            migrationBuilder.AddColumn<string>(
                name: "PartOfSpeech",
                table: "Translate",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 158, 63, 197, 187, 226, 135, 142, 27, 69, 7, 9, 124, 64, 95, 78, 172, 36, 60, 124, 244, 239, 102, 207, 8, 230, 37, 63, 136, 160, 106, 5, 67, 190, 251, 10, 249, 232, 26, 136, 22, 43, 167, 237, 52, 55, 109, 113, 191, 78, 75, 151, 151, 175, 56, 25, 59, 93, 42, 217, 114, 242, 164, 100, 56 }, "67E3AF3B083DBD5B7943E0B6CEB2591A658A347509FD4572DBD400CC3C78BA4461FB8B49573C93EA1A86CBE7CD66B78447BAC357628F0AAEAF74B1FBF9AF5A24" });

            migrationBuilder.CreateIndex(
                name: "IX_Expressions_Text_LanguageId",
                table: "Expressions",
                columns: new[] { "Text", "LanguageId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expressions_Text_LanguageId",
                table: "Expressions");

            migrationBuilder.DropColumn(
                name: "PartOfSpeech",
                table: "Translate");

            migrationBuilder.AddColumn<string>(
                name: "PartOfSpeech",
                table: "Expressions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 109, 191, 56, 3, 57, 130, 31, 82, 181, 206, 66, 42, 194, 139, 30, 74, 54, 74, 203, 1, 174, 33, 102, 166, 30, 127, 11, 167, 199, 100, 108, 55, 248, 213, 210, 76, 149, 22, 247, 58, 190, 225, 189, 75, 150, 87, 56, 77, 46, 208, 80, 39, 4, 46, 239, 7, 153, 88, 193, 150, 91, 26, 19, 70 }, "D87ADB03DFA1EB67BDCED794B522FED629DCE6BA4015BBCE8E3A545502C5BAA6E1552E62A884A9B76913B96FC249A6FE63786FA404C3FBC7DA5D7DCF9571962D" });

            migrationBuilder.CreateIndex(
                name: "IX_Expressions_Text_PartOfSpeech_LanguageId",
                table: "Expressions",
                columns: new[] { "Text", "PartOfSpeech", "LanguageId" },
                unique: true);
        }
    }
}
