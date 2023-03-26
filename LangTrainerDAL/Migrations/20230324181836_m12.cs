using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class m12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 45, 62, 25, 227, 198, 240, 94, 199, 253, 1, 24, 55, 2, 192, 220, 238, 81, 249, 91, 207, 29, 73, 220, 140, 94, 189, 46, 73, 122, 236, 232, 250, 102, 143, 43, 136, 249, 102, 221, 60, 105, 245, 205, 175, 83, 189, 164, 249, 11, 150, 136, 20, 201, 232, 19, 241, 74, 77, 150, 195, 124, 84, 140, 248 }, "8FE06B3AFC9E37893D6FA0E60AB0B712487EA602DE58BED3333F68E8B02C1AE32724C005EA0DAEA9AE0B11CEF62F06F99E10362E87E65318FA99C74C96D26574" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "PassSalt", "PasswordHash" },
                values: new object[] { new Guid("e3db5e30-1c0e-432c-920d-7160d71f8d35"), "alekseyt9@gmail.com", "test", new byte[] { 87, 125, 99, 189, 149, 142, 6, 252, 18, 25, 224, 188, 188, 188, 150, 120, 92, 184, 149, 108, 237, 204, 144, 78, 128, 73, 210, 255, 248, 22, 226, 35, 89, 129, 204, 25, 158, 60, 168, 152, 118, 185, 207, 23, 124, 188, 30, 102, 251, 21, 48, 56, 83, 172, 151, 102, 190, 198, 69, 141, 170, 1, 13, 151 }, "5E96EED165086C76D0F32322BCB2960B3A46627A87678BE4B3BFFCEC1926F6DE207D5C3A1CB3A62C60DC6D1B9D28BB1D9C4921B820551CA292CF221EF02B8F8B" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3db5e30-1c0e-432c-920d-7160d71f8d35"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                columns: new[] { "PassSalt", "PasswordHash" },
                values: new object[] { new byte[] { 183, 120, 247, 142, 9, 213, 196, 215, 223, 75, 171, 159, 198, 91, 83, 226, 131, 200, 85, 240, 253, 26, 24, 215, 68, 162, 153, 55, 54, 114, 117, 199, 55, 81, 82, 108, 245, 122, 234, 38, 29, 150, 11, 9, 150, 228, 171, 182, 112, 198, 224, 245, 81, 32, 207, 208, 76, 157, 81, 86, 129, 201, 194, 40 }, "B85053CA661F851BBDE56412C377AEC6D797850425A097D4CB3A3963C3EA396849EC3EDEFE76D90E23207BA2162AA6072EEA1C02244B30D372553E58BE08E21D" });
        }
    }
}
