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
                    { new Guid("26ad8332-1472-486c-b042-4b9eee4ff9e5"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("2b90292e-28da-46a5-a256-3dc3d9993b4b"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("9353cc10-8e92-4190-803a-563d14d5e3a5"), 1, "3.Who is your favourite actor?" },
                    { new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("e3ef3359-4f3a-4a3b-bd20-c01821603707"), 2, "4.Who is your favourite director?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("134817d0-5597-46b2-8c1c-d9a52bbace85"), new Guid("9353cc10-8e92-4190-803a-563d14d5e3a5"), null },
                    { new Guid("1d673f1d-e1e4-49dc-a4f2-9c3bac17c94e"), new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), "Horror" },
                    { new Guid("206e7443-3404-4db8-9a3b-7993baa7d1bc"), new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), "Thriller" },
                    { new Guid("30fd1543-f191-4c72-b685-d613e2a58e6e"), new Guid("2b90292e-28da-46a5-a256-3dc3d9993b4b"), "Not at all often" },
                    { new Guid("5fbe5531-2bab-4311-b894-2239a3229957"), new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), "Drama" },
                    { new Guid("6b964967-4412-4617-b8d9-dd96608aaa2a"), new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), "Comedy" },
                    { new Guid("7db810be-f6af-4dd0-a295-57e4f65e74de"), new Guid("e3ef3359-4f3a-4a3b-bd20-c01821603707"), null },
                    { new Guid("7f7fdd5d-110b-4082-9036-519292a7ae32"), new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), "Musical" },
                    { new Guid("86f02947-46f7-49de-9fa1-27f6d1e6bcce"), new Guid("2b90292e-28da-46a5-a256-3dc3d9993b4b"), "Very often" },
                    { new Guid("94acb601-a7de-4e6a-90d0-9c4b8f37c8cc"), new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), "Romance" },
                    { new Guid("bb96a9cf-58c6-4a32-b1f8-767e2f0dc8ee"), new Guid("2b90292e-28da-46a5-a256-3dc3d9993b4b"), "Slightly often" },
                    { new Guid("c047c073-dad2-4dc5-ab8a-f0a496c24c2b"), new Guid("2b90292e-28da-46a5-a256-3dc3d9993b4b"), "Moderately often" },
                    { new Guid("ca43832d-926a-4ab8-8380-0a8b015ef3c3"), new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), "Action/Adventure" },
                    { new Guid("db1517ef-f746-47e0-930e-48d351bb4707"), new Guid("2b90292e-28da-46a5-a256-3dc3d9993b4b"), "Extremely often" },
                    { new Guid("e69ab1e6-8e25-45f2-b0d7-f8e1090ac71a"), new Guid("26ad8332-1472-486c-b042-4b9eee4ff9e5"), null },
                    { new Guid("f8f9828e-0862-4402-961d-a9f67b37a0c4"), new Guid("cf403395-0f5a-40d2-a744-92ecd8b8774d"), "Science-Fiction" }
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
