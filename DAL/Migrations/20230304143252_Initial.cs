using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    SurveyQuestionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.SurveyQuestionGUID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserGUID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswers",
                columns: table => new
                {
                    SurveyAnswerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyQuestionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswers", x => x.SurveyAnswerGUID);
                    table.ForeignKey(
                        name: "FK_SurveyAnswers_SurveyQuestions_SurveyQuestionGUID",
                        column: x => x.SurveyQuestionGUID,
                        principalTable: "SurveyQuestions",
                        principalColumn: "SurveyQuestionGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswersUsers",
                columns: table => new
                {
                    SurveyAnswersSurveyAnswerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUserGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswersUsers", x => new { x.SurveyAnswersSurveyAnswerGUID, x.UsersUserGUID });
                    table.ForeignKey(
                        name: "FK_SurveyAnswersUsers_SurveyAnswers_SurveyAnswersSurveyAnswerGUID",
                        column: x => x.SurveyAnswersSurveyAnswerGUID,
                        principalTable: "SurveyAnswers",
                        principalColumn: "SurveyAnswerGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyAnswersUsers_Users_UsersUserGUID",
                        column: x => x.UsersUserGUID,
                        principalTable: "Users",
                        principalColumn: "UserGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("13e40ae9-09f9-4bb0-9bf9-da77885fe7fe"), 2, "4.Who is your favourite director?" },
                    { new Guid("23efff79-ee79-4692-8264-2196e07770d0"), 1, "3.Who is your favourite actor?" },
                    { new Guid("7a4e6704-e8aa-415c-af33-e30e31d2afdd"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("af0b4627-6d33-4377-8a13-f1939c4e5c41"), 3, "1.How frequently do you watch movies?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("0052b03d-6155-4655-9ee6-e697c66441b6"), new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), "Science-Fiction" },
                    { new Guid("01c3bee8-9502-4651-8a5c-827ca1755b22"), new Guid("23efff79-ee79-4692-8264-2196e07770d0"), null },
                    { new Guid("04cb7327-8782-448a-a901-bbce363c001b"), new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), "Thriller" },
                    { new Guid("0fe9d79a-bcff-4723-b7aa-3d632489d876"), new Guid("af0b4627-6d33-4377-8a13-f1939c4e5c41"), "Very often" },
                    { new Guid("43b46f29-9302-4935-bee4-672ecf441d8e"), new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), "Romance" },
                    { new Guid("6c8e3b1c-0bf5-4db6-a31e-ccfbd477e2d8"), new Guid("af0b4627-6d33-4377-8a13-f1939c4e5c41"), "Not at all often" },
                    { new Guid("6df6d514-9125-4fa5-94f6-a2850d4143ec"), new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), "Musical" },
                    { new Guid("8aa86e69-a8fe-42d9-8da7-22a4bac7e538"), new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), "Comedy" },
                    { new Guid("8f54486e-bdaf-4221-a544-c08186255420"), new Guid("7a4e6704-e8aa-415c-af33-e30e31d2afdd"), null },
                    { new Guid("9fcbee6c-4cf5-435e-b43b-e36802306d06"), new Guid("13e40ae9-09f9-4bb0-9bf9-da77885fe7fe"), null },
                    { new Guid("a337bb44-e13c-4f0d-b64d-e5831fc11387"), new Guid("af0b4627-6d33-4377-8a13-f1939c4e5c41"), "Moderately often" },
                    { new Guid("a41538c2-3078-4eef-a396-032c06a09753"), new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), "Action/Adventure" },
                    { new Guid("ababcdc7-cb13-4bde-a60e-f6226070b6a0"), new Guid("af0b4627-6d33-4377-8a13-f1939c4e5c41"), "Extremely often" },
                    { new Guid("b4cc6044-8728-40ea-887a-d0bce2348a1a"), new Guid("af0b4627-6d33-4377-8a13-f1939c4e5c41"), "Slightly often" },
                    { new Guid("b9a0f8e6-b87e-4812-ace3-682149411c0b"), new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), "Drama" },
                    { new Guid("f35ad373-662d-43d9-bfe2-6d71d65f94a8"), new Guid("a8b16aab-e87e-4a23-9c1c-d33c7087f273"), "Horror" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_SurveyQuestionGUID",
                table: "SurveyAnswers",
                column: "SurveyQuestionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswersUsers_UsersUserGUID",
                table: "SurveyAnswersUsers",
                column: "UsersUserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyAnswersUsers");

            migrationBuilder.DropTable(
                name: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");
        }
    }
}
