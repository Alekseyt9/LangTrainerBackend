using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingGroup_Users_UserId",
                table: "TrainingGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslateInGroup_TrainingGroup_GroupId",
                table: "TranslateInGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingGroup",
                table: "TrainingGroup");

            migrationBuilder.RenameTable(
                name: "TrainingGroup",
                newName: "TrainingGroups");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingGroup_UserId",
                table: "TrainingGroups",
                newName: "IX_TrainingGroups_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingGroups",
                table: "TrainingGroups",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 245, 221, 95, 20, 21, 192, 17, 56, 147, 226, 185, 54, 216, 17, 37, 128, 35, 135, 106, 73, 172, 138, 182, 121, 146, 83, 34, 116, 35, 180, 66, 95, 149, 164, 163, 23, 202, 125, 57, 119, 52, 52, 89, 28, 226, 126, 21, 85, 27, 158, 111, 52, 165, 254, 27, 164, 84, 41, 76, 54, 74, 197, 53, 233 }, "EC36C360E0B4AE5B57091C83493D80F274C2420FDFC6D4A1517054DC22A80F331DBD78D7FEE2FDA6C9AC8EF78DD026A1AA5F83EBEB3BD87EE773BF61E87EC9CE" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingGroups_Users_UserId",
                table: "TrainingGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslateInGroup_TrainingGroups_GroupId",
                table: "TranslateInGroup",
                column: "GroupId",
                principalTable: "TrainingGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingGroups_Users_UserId",
                table: "TrainingGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslateInGroup_TrainingGroups_GroupId",
                table: "TranslateInGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingGroups",
                table: "TrainingGroups");

            migrationBuilder.RenameTable(
                name: "TrainingGroups",
                newName: "TrainingGroup");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingGroups_UserId",
                table: "TrainingGroup",
                newName: "IX_TrainingGroup_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingGroup",
                table: "TrainingGroup",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 197, 9, 49, 243, 213, 215, 45, 163, 98, 2, 27, 10, 165, 177, 209, 11, 94, 124, 40, 88, 7, 224, 3, 227, 242, 152, 235, 37, 207, 217, 130, 208, 86, 239, 185, 147, 76, 12, 121, 50, 63, 165, 231, 173, 162, 105, 177, 20, 148, 141, 40, 64, 105, 229, 165, 106, 223, 16, 21, 52, 130, 26, 74, 24 }, "057F246B8A85F9F668C80602BF05DA0E984C2C859D550B78556976780B431474DB0F9D18D564E2367078FAEECCFFFE0AF6632F6381EEDAC5E044969A77401A2D" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingGroup_Users_UserId",
                table: "TrainingGroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslateInGroup_TrainingGroup_GroupId",
                table: "TranslateInGroup",
                column: "GroupId",
                principalTable: "TrainingGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
