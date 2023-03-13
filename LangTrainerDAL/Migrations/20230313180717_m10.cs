using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sample_Translate_TranslateId",
                table: "Sample");

            migrationBuilder.DropForeignKey(
                name: "FK_Translate_Expressions_ExpressionId",
                table: "Translate");

            migrationBuilder.DropForeignKey(
                name: "FK_Translate_Languages_LanguageId",
                table: "Translate");

            migrationBuilder.DropForeignKey(
                name: "FK_Translate_PartOfSpeech_PartOfSpeechId",
                table: "Translate");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslateInGroup_Translate_TranslateId",
                table: "TranslateInGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translate",
                table: "Translate");

            migrationBuilder.RenameTable(
                name: "Translate",
                newName: "Translates");

            migrationBuilder.RenameIndex(
                name: "IX_Translate_PartOfSpeechId",
                table: "Translates",
                newName: "IX_Translates_PartOfSpeechId");

            migrationBuilder.RenameIndex(
                name: "IX_Translate_LanguageId",
                table: "Translates",
                newName: "IX_Translates_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Translate_ExpressionId",
                table: "Translates",
                newName: "IX_Translates_ExpressionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translates",
                table: "Translates",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 183, 120, 247, 142, 9, 213, 196, 215, 223, 75, 171, 159, 198, 91, 83, 226, 131, 200, 85, 240, 253, 26, 24, 215, 68, 162, 153, 55, 54, 114, 117, 199, 55, 81, 82, 108, 245, 122, 234, 38, 29, 150, 11, 9, 150, 228, 171, 182, 112, 198, 224, 245, 81, 32, 207, 208, 76, 157, 81, 86, 129, 201, 194, 40 }, "B85053CA661F851BBDE56412C377AEC6D797850425A097D4CB3A3963C3EA396849EC3EDEFE76D90E23207BA2162AA6072EEA1C02244B30D372553E58BE08E21D" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sample_Translates_TranslateId",
                table: "Sample",
                column: "TranslateId",
                principalTable: "Translates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslateInGroup_Translates_TranslateId",
                table: "TranslateInGroup",
                column: "TranslateId",
                principalTable: "Translates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translates_Expressions_ExpressionId",
                table: "Translates",
                column: "ExpressionId",
                principalTable: "Expressions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translates_Languages_LanguageId",
                table: "Translates",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translates_PartOfSpeech_PartOfSpeechId",
                table: "Translates",
                column: "PartOfSpeechId",
                principalTable: "PartOfSpeech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sample_Translates_TranslateId",
                table: "Sample");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslateInGroup_Translates_TranslateId",
                table: "TranslateInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Translates_Expressions_ExpressionId",
                table: "Translates");

            migrationBuilder.DropForeignKey(
                name: "FK_Translates_Languages_LanguageId",
                table: "Translates");

            migrationBuilder.DropForeignKey(
                name: "FK_Translates_PartOfSpeech_PartOfSpeechId",
                table: "Translates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translates",
                table: "Translates");

            migrationBuilder.RenameTable(
                name: "Translates",
                newName: "Translate");

            migrationBuilder.RenameIndex(
                name: "IX_Translates_PartOfSpeechId",
                table: "Translate",
                newName: "IX_Translate_PartOfSpeechId");

            migrationBuilder.RenameIndex(
                name: "IX_Translates_LanguageId",
                table: "Translate",
                newName: "IX_Translate_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Translates_ExpressionId",
                table: "Translate",
                newName: "IX_Translate_ExpressionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translate",
                table: "Translate",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 252, 254, 103, 126, 80, 204, 32, 113, 226, 74, 183, 129, 76, 147, 96, 96, 111, 122, 147, 223, 84, 0, 201, 228, 143, 160, 111, 189, 1, 149, 109, 89, 122, 250, 210, 90, 112, 110, 198, 13, 146, 155, 236, 2, 101, 92, 205, 143, 251, 72, 28, 189, 65, 35, 148, 186, 32, 143, 118, 182, 47, 160, 115, 23 }, "2DDBE07D9785A8D2B060F965E1A47FC3F8DB1C45C4CA8C50D8748A6D16991E6225306D371C9A26A721743D1E67C258914D8960C7949BE28C4DFB4B11DFB575CB" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sample_Translate_TranslateId",
                table: "Sample",
                column: "TranslateId",
                principalTable: "Translate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translate_Expressions_ExpressionId",
                table: "Translate",
                column: "ExpressionId",
                principalTable: "Expressions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translate_Languages_LanguageId",
                table: "Translate",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translate_PartOfSpeech_PartOfSpeechId",
                table: "Translate",
                column: "PartOfSpeechId",
                principalTable: "PartOfSpeech",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslateInGroup_Translate_TranslateId",
                table: "TranslateInGroup",
                column: "TranslateId",
                principalTable: "Translate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
