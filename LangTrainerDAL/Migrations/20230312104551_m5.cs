using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartOfSpeech",
                table: "Translate");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "TranslateInGroup",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PartOfSpeechId",
                table: "Translate",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PartOfSpeech",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfSpeech", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartOfSpeech_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 133, 10, 64, 150, 104, 40, 68, 131, 123, 160, 201, 62, 245, 119, 186, 212, 115, 190, 211, 225, 39, 186, 218, 129, 26, 235, 169, 165, 151, 227, 119, 240, 100, 23, 24, 180, 169, 46, 96, 139, 112, 86, 29, 187, 196, 179, 110, 229, 171, 220, 133, 18, 191, 100, 177, 158, 89, 243, 224, 59, 19, 21, 98, 172 }, "007954B33EF6D282CBBB883DE8D1903477AE7DA810965D29AB2C13940A924B4B99724A8DE3DD007D658FD2677AC43A6400D1C1D0F2153673E5881268FE010187" });

            migrationBuilder.CreateIndex(
                name: "IX_Translate_PartOfSpeechId",
                table: "Translate",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOfSpeech_LanguageId",
                table: "PartOfSpeech",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translate_PartOfSpeech_PartOfSpeechId",
                table: "Translate",
                column: "PartOfSpeechId",
                principalTable: "PartOfSpeech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translate_PartOfSpeech_PartOfSpeechId",
                table: "Translate");

            migrationBuilder.DropTable(
                name: "PartOfSpeech");

            migrationBuilder.DropIndex(
                name: "IX_Translate_PartOfSpeechId",
                table: "Translate");

            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "TranslateInGroup");

            migrationBuilder.DropColumn(
                name: "PartOfSpeechId",
                table: "Translate");

            migrationBuilder.AddColumn<string>(
                name: "PartOfSpeech",
                table: "Translate",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 79, 223, 227, 216, 147, 6, 131, 149, 196, 164, 65, 135, 161, 44, 65, 56, 202, 105, 7, 126, 55, 107, 49, 182, 194, 208, 210, 106, 102, 189, 25, 74, 42, 234, 111, 122, 26, 126, 16, 218, 121, 105, 26, 30, 193, 141, 20, 220, 197, 165, 223, 115, 105, 137, 86, 41, 183, 251, 58, 249, 255, 25, 145, 2 }, "DA8011B71FC59E71DAA35FE017C3A255446CACF4EBC74A416835E54F4326D8442DAF9D83840492449F40793087FD8E74C679238515E665F27FB9F83E0C179996" });
        }
    }
}
