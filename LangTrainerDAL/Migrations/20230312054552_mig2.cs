using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expressions_Text_PartOfSpeech_LanguageId",
                table: "Expressions");

            migrationBuilder.DropColumn(
                name: "PartOfSpeech",
                table: "Expressions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 223, 196, 27, 169, 141, 56, 1, 184, 201, 65, 140, 255, 177, 207, 147, 215, 113, 143, 181, 42, 25, 106, 101, 94, 52, 114, 252, 230, 76, 157, 133, 124, 118, 187, 126, 204, 228, 113, 142, 28, 16, 177, 248, 220, 26, 224, 35, 83, 172, 119, 206, 18, 33, 241, 231, 33, 152, 101, 76, 198, 108, 81, 120, 242 }, "C6D4A4AB578A4F73A688C71D56E0E864C37D02CCB9A2C46BC18B265F58100DC259688C904C57D6F7BD414D50F97941B6644DDAFA805C56D4E648C6FF66942467" });
        }
    }
}
