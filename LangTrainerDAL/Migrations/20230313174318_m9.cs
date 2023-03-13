using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInfo_TranslateInGroup_TranslateInGroupId",
                table: "TrainingInfo");

            migrationBuilder.DropIndex(
                name: "IX_TrainingInfo_TranslateInGroupId",
                table: "TrainingInfo");

            migrationBuilder.DropColumn(
                name: "TranslateInGroupId",
                table: "TrainingInfo");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 252, 254, 103, 126, 80, 204, 32, 113, 226, 74, 183, 129, 76, 147, 96, 96, 111, 122, 147, 223, 84, 0, 201, 228, 143, 160, 111, 189, 1, 149, 109, 89, 122, 250, 210, 90, 112, 110, 198, 13, 146, 155, 236, 2, 101, 92, 205, 143, 251, 72, 28, 189, 65, 35, 148, 186, 32, 143, 118, 182, 47, 160, 115, 23 }, "2DDBE07D9785A8D2B060F965E1A47FC3F8DB1C45C4CA8C50D8748A6D16991E6225306D371C9A26A721743D1E67C258914D8960C7949BE28C4DFB4B11DFB575CB" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TranslateInGroupId",
                table: "TrainingInfo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 245, 221, 95, 20, 21, 192, 17, 56, 147, 226, 185, 54, 216, 17, 37, 128, 35, 135, 106, 73, 172, 138, 182, 121, 146, 83, 34, 116, 35, 180, 66, 95, 149, 164, 163, 23, 202, 125, 57, 119, 52, 52, 89, 28, 226, 126, 21, 85, 27, 158, 111, 52, 165, 254, 27, 164, 84, 41, 76, 54, 74, 197, 53, 233 }, "EC36C360E0B4AE5B57091C83493D80F274C2420FDFC6D4A1517054DC22A80F331DBD78D7FEE2FDA6C9AC8EF78DD026A1AA5F83EBEB3BD87EE773BF61E87EC9CE" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInfo_TranslateInGroupId",
                table: "TrainingInfo",
                column: "TranslateInGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInfo_TranslateInGroup_TranslateInGroupId",
                table: "TrainingInfo",
                column: "TranslateInGroupId",
                principalTable: "TranslateInGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
