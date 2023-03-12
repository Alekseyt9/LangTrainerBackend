using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartOfSpeech_LanguageId",
                table: "PartOfSpeech");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 170, 78, 229, 123, 3, 101, 81, 213, 56, 79, 84, 232, 27, 240, 71, 183, 54, 74, 9, 43, 96, 3, 151, 222, 159, 115, 237, 43, 115, 143, 239, 177, 117, 86, 1, 222, 235, 140, 169, 181, 54, 95, 133, 12, 58, 199, 67, 25, 239, 124, 64, 9, 9, 125, 87, 253, 110, 21, 12, 100, 106, 70, 193, 102 }, "551466C676AD62E66F82C26B7A87A75632B9E0181839649023A3F37D6BB2AF761851DC0CF837FB15C8BEC2E4686BE7FE8E7AE6CDB361FD1FF495C83FD11C4EC7" });

            migrationBuilder.CreateIndex(
                name: "IX_PartOfSpeech_LanguageId_Name",
                table: "PartOfSpeech",
                columns: new[] { "LanguageId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartOfSpeech_LanguageId_Name",
                table: "PartOfSpeech");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 133, 10, 64, 150, 104, 40, 68, 131, 123, 160, 201, 62, 245, 119, 186, 212, 115, 190, 211, 225, 39, 186, 218, 129, 26, 235, 169, 165, 151, 227, 119, 240, 100, 23, 24, 180, 169, 46, 96, 139, 112, 86, 29, 187, 196, 179, 110, 229, 171, 220, 133, 18, 191, 100, 177, 158, 89, 243, 224, 59, 19, 21, 98, 172 }, "007954B33EF6D282CBBB883DE8D1903477AE7DA810965D29AB2C13940A924B4B99724A8DE3DD007D658FD2677AC43A6400D1C1D0F2153673E5881268FE010187" });

            migrationBuilder.CreateIndex(
                name: "IX_PartOfSpeech_LanguageId",
                table: "PartOfSpeech",
                column: "LanguageId");
        }
    }
}
