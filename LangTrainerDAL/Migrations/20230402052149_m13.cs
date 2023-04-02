using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "Email", "PassSalt", "PasswordHash" },
                values: new object[] { "admin", new byte[] { 201, 254, 26, 182, 57, 244, 173, 159, 40, 27, 132, 90, 165, 16, 58, 74, 147, 54, 75, 233, 34, 31, 96, 60, 64, 147, 213, 157, 104, 147, 236, 26, 186, 81, 228, 179, 251, 155, 109, 163, 187, 245, 185, 176, 69, 32, 64, 162, 252, 85, 157, 201, 57, 72, 236, 14, 55, 253, 146, 156, 254, 178, 140, 131 }, "1154F42C027E08B499A97B73C72DEDF46E3EB4E6BDC8261C5137A94F6820658B0AC39C6110B259F34D9C5A35D51908361FEBBF4E3E16AD3B32A0782729400921" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3db5e30-1c0e-432c-920d-7160d71f8d35"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 127, 133, 147, 63, 100, 219, 88, 46, 124, 51, 228, 167, 97, 39, 181, 46, 250, 91, 115, 157, 61, 245, 114, 16, 69, 255, 177, 208, 205, 154, 232, 186, 153, 93, 228, 200, 40, 255, 48, 205, 207, 3, 163, 83, 247, 51, 114, 250, 211, 141, 171, 1, 231, 82, 56, 192, 27, 254, 68, 101, 240, 132, 251, 238 }, "8C13AF3D0DFDE5C40F124DF9ABBA36741E262ED77F4C1DC52089C3330A274400B5F6C744F0AB276FB65CAB2D9827DEE9057E232020949868230A8A813A9C8F65" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "Email", "Login", "PassSalt", "PasswordHash" },
                values: new object[] { "-", "admin", new byte[] { 45, 62, 25, 227, 198, 240, 94, 199, 253, 1, 24, 55, 2, 192, 220, 238, 81, 249, 91, 207, 29, 73, 220, 140, 94, 189, 46, 73, 122, 236, 232, 250, 102, 143, 43, 136, 249, 102, 221, 60, 105, 245, 205, 175, 83, 189, 164, 249, 11, 150, 136, 20, 201, 232, 19, 241, 74, 77, 150, 195, 124, 84, 140, 248 }, "8FE06B3AFC9E37893D6FA0E60AB0B712487EA602DE58BED3333F68E8B02C1AE32724C005EA0DAEA9AE0B11CEF62F06F99E10362E87E65318FA99C74C96D26574" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3db5e30-1c0e-432c-920d-7160d71f8d35"),
                columns: new[] { "Login", "PassSalt", "PasswordHash" },
                values: new object[] { "test", new byte[] { 87, 125, 99, 189, 149, 142, 6, 252, 18, 25, 224, 188, 188, 188, 150, 120, 92, 184, 149, 108, 237, 204, 144, 78, 128, 73, 210, 255, 248, 22, 226, 35, 89, 129, 204, 25, 158, 60, 168, 152, 118, 185, 207, 23, 124, 188, 30, 102, 251, 21, 48, 56, 83, 172, 151, 102, 190, 198, 69, 141, 170, 1, 13, 151 }, "5E96EED165086C76D0F32322BCB2960B3A46627A87678BE4B3BFFCEC1926F6DE207D5C3A1CB3A62C60DC6D1B9D28BB1D9C4921B820551CA292CF221EF02B8F8B" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }
    }
}
