using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LangTrainerDAL.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PassSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expressions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expressions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expressions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingGroup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sound",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<byte[]>(type: "bytea", nullable: false),
                    Hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    ExpressionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sound_Expressions_ExpressionId",
                        column: x => x.ExpressionId,
                        principalTable: "Expressions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpressionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translate_Expressions_ExpressionId",
                        column: x => x.ExpressionId,
                        principalTable: "Expressions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translate_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sample",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    TranslateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sample_Translate_TranslateId",
                        column: x => x.TranslateId,
                        principalTable: "Translate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastSuccessTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Stage = table.Column<int>(type: "integer", nullable: false),
                    TranslateInGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslateInGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    TranslateId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateInGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslateInGroup_TrainingGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "TrainingGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslateInGroup_TrainingInfo_TrainingInfoId",
                        column: x => x.TrainingInfoId,
                        principalTable: "TrainingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslateInGroup_Translate_TranslateId",
                        column: x => x.TranslateId,
                        principalTable: "Translate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04dbc458-0835-47f2-8140-432376686536"), "spanish" },
                    { new Guid("29425483-c990-4ec9-9f1e-4658eed1cad2"), "russian" },
                    { new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"), "english" },
                    { new Guid("4c2916c7-e10e-4579-91c6-39c37965ddb1"), "french" },
                    { new Guid("e52926ee-64f1-4b04-8a7e-187c5d0213c8"), "italian" },
                    { new Guid("ee8f502d-437c-4378-a1a2-e5d7a3b3b29e"), "german" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "PassSalt", "PasswordHash" },
                values: new object[] { new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"), "-", "admin", new byte[] { 223, 196, 27, 169, 141, 56, 1, 184, 201, 65, 140, 255, 177, 207, 147, 215, 113, 143, 181, 42, 25, 106, 101, 94, 52, 114, 252, 230, 76, 157, 133, 124, 118, 187, 126, 204, 228, 113, 142, 28, 16, 177, 248, 220, 26, 224, 35, 83, 172, 119, 206, 18, 33, 241, 231, 33, 152, 101, 76, 198, 108, 81, 120, 242 }, "C6D4A4AB578A4F73A688C71D56E0E864C37D02CCB9A2C46BC18B265F58100DC259688C904C57D6F7BD414D50F97941B6644DDAFA805C56D4E648C6FF66942467" });

            migrationBuilder.CreateIndex(
                name: "IX_Expressions_LanguageId",
                table: "Expressions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sample_TranslateId",
                table: "Sample",
                column: "TranslateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sound_ExpressionId",
                table: "Sound",
                column: "ExpressionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGroup_UserId",
                table: "TrainingGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInfo_TranslateInGroupId",
                table: "TrainingInfo",
                column: "TranslateInGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Translate_ExpressionId",
                table: "Translate",
                column: "ExpressionId");

            migrationBuilder.CreateIndex(
                name: "IX_Translate_LanguageId",
                table: "Translate",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateInGroup_GroupId",
                table: "TranslateInGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateInGroup_TrainingInfoId",
                table: "TranslateInGroup",
                column: "TrainingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateInGroup_TranslateId",
                table: "TranslateInGroup",
                column: "TranslateId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingInfo_TranslateInGroup_TranslateInGroupId",
                table: "TrainingInfo",
                column: "TranslateInGroupId",
                principalTable: "TranslateInGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expressions_Languages_LanguageId",
                table: "Expressions");

            migrationBuilder.DropForeignKey(
                name: "FK_Translate_Languages_LanguageId",
                table: "Translate");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslateInGroup_Translate_TranslateId",
                table: "TranslateInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingGroup_Users_UserId",
                table: "TrainingGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingInfo_TranslateInGroup_TranslateInGroupId",
                table: "TrainingInfo");

            migrationBuilder.DropTable(
                name: "Sample");

            migrationBuilder.DropTable(
                name: "Sound");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Translate");

            migrationBuilder.DropTable(
                name: "Expressions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TranslateInGroup");

            migrationBuilder.DropTable(
                name: "TrainingGroup");

            migrationBuilder.DropTable(
                name: "TrainingInfo");
        }
    }
}
