using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    SurveyQuestionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
