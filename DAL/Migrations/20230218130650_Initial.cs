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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("13d3263b-a9e1-47f4-a3f3-f439ffe73bb8"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("5e440fc9-6e23-4656-bfc8-e41149e18808"), 1, "3.Who is your favourite actor?" },
                    { new Guid("ac3f76a8-a404-4c52-a418-140d6203a0bb"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("d33e780a-3bb5-4da9-a9cf-6bf052d53a96"), 2, "4.Who is your favourite director?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("1072e9cb-908c-43cd-bbb7-68bd671a0e0d"), new Guid("13d3263b-a9e1-47f4-a3f3-f439ffe73bb8"), "Extremely often" },
                    { new Guid("1a1002f7-2268-42ee-9823-7bcfdb7606bb"), new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), "Thriller" },
                    { new Guid("2d293d69-e613-475c-a7e7-507906742cd1"), new Guid("d33e780a-3bb5-4da9-a9cf-6bf052d53a96"), null },
                    { new Guid("59480e9a-eb08-4407-992a-19ae6ba73ae4"), new Guid("13d3263b-a9e1-47f4-a3f3-f439ffe73bb8"), "Moderately often" },
                    { new Guid("5e9349c4-8e25-445b-8a3c-6ea69d2267c5"), new Guid("13d3263b-a9e1-47f4-a3f3-f439ffe73bb8"), "Slightly often" },
                    { new Guid("61bb3a70-3128-4a99-9955-b8164a197d7e"), new Guid("13d3263b-a9e1-47f4-a3f3-f439ffe73bb8"), "Very often" },
                    { new Guid("6a5b1785-3adf-4933-95eb-15193f885135"), new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), "Romance" },
                    { new Guid("6e83041b-2c00-4fe7-8330-fd668cae33a4"), new Guid("13d3263b-a9e1-47f4-a3f3-f439ffe73bb8"), "Not at all often" },
                    { new Guid("883c5483-6d28-4fab-ac2f-ac6b48ca34a8"), new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), "Comedy" },
                    { new Guid("9c31dc0c-ddf8-49a7-b679-1c0d35ac62cb"), new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), "Drama" },
                    { new Guid("bbfcc9fd-38bc-4cf8-b002-489f825c07bf"), new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), "Action/Adventure" },
                    { new Guid("c8153397-3be7-4ffb-909e-c768ffaaf79b"), new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), "Science-Fiction" },
                    { new Guid("cfecac5c-d99c-4144-9ce7-8037ac9bdcab"), new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), "Musical" },
                    { new Guid("dbf44912-4f51-491d-bbef-58c7aee78098"), new Guid("cbded710-7709-4f19-86b3-bcb5d6989402"), "Horror" },
                    { new Guid("dce80b33-501f-4d4b-a2bf-85d2b72bbe0b"), new Guid("5e440fc9-6e23-4656-bfc8-e41149e18808"), null },
                    { new Guid("e056a827-ea14-489e-8159-2309ce905dd9"), new Guid("ac3f76a8-a404-4c52-a418-140d6203a0bb"), null }
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
