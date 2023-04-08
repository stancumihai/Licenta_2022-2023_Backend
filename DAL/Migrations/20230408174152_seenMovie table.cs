using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seenMovietable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("0e2c85eb-031a-4e0c-b9b5-56bfa1c3757b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("0fd432d1-8cea-4911-b9fa-84fe5064dee6"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("144ff9bb-b1a3-4b94-bc85-7efeb8298159"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("2a3254d0-0597-4edc-973c-9faccf83e3f4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("30a998ca-b1cb-4546-830f-19b929be9a4b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("45a07eaf-0e86-444a-a0e0-e6536af21ad2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("4c40bb61-b50e-43ab-8a27-295fab186533"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7f3d8175-6a65-4341-8482-18b3809989ce"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7f5c2559-17d3-483b-a4ac-7f8709bf0b7e"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a37fbbcb-a83a-4280-8106-423c26ec5a73"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a62fce64-606d-4194-bdd0-b8435903e1a9"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ababf92c-37b5-4ec6-b091-e75dd12f5a08"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b13b5642-33a6-4fbe-93d2-1908cf941c7d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c5adcf0f-5416-492a-be21-dd090baf15d7"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cdd05ed4-7a3a-4c1a-832d-a444e721c5fd"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("de6fcaec-74f6-4103-bc60-e1c343a21f00"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("1252e712-6ecd-42a2-b59a-0d6951c9688e"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("be4c17da-c102-43cd-83d6-73abf2a61ecb"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("d18549f2-e3ea-46cf-837a-1e93f2c914aa"));

            migrationBuilder.CreateTable(
                name: "SeenMovies",
                columns: table => new
                {
                    SeenMovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeenMovies", x => x.SeenMovieGUID);
                    table.ForeignKey(
                        name: "FK_SeenMovies_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeenMovies_Movies_MovieGUID",
                        column: x => x.MovieGUID,
                        principalTable: "Movies",
                        principalColumn: "MovieGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("72ca54af-43c1-481a-82ef-aef117f1c09b"), 1, "3.Who is your favourite actor?" },
                    { new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("c28c92ba-afa1-406c-b07e-f0611133187a"), 2, "4.Who is your favourite director?" },
                    { new Guid("e2e67ba5-7387-44ea-8957-a964f81f2138"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("02ae396b-c39e-4039-88e1-0a5bf8220cf0"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Horror" },
                    { new Guid("082286b0-8459-4775-93e9-5b78c28a8f80"), new Guid("c28c92ba-afa1-406c-b07e-f0611133187a"), "" },
                    { new Guid("1242bcdd-639f-4a95-b637-52983404bbaf"), new Guid("72ca54af-43c1-481a-82ef-aef117f1c09b"), "" },
                    { new Guid("199177f5-9fec-4466-bfea-4916e08e3020"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Very often" },
                    { new Guid("5dd625b2-5149-4188-8a07-808928fc228d"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Extremely often" },
                    { new Guid("79e99f78-ae0a-4330-97b0-3f25f327eb8d"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Action/Adventure" },
                    { new Guid("8e040ca0-51df-493a-b67d-a997edf559de"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Moderately often" },
                    { new Guid("948f7a9d-aa95-4edf-8fce-b061af1d70f2"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Science-Fiction" },
                    { new Guid("a1978dc5-bee9-4449-afe5-d26cbdb80c3e"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Thriller" },
                    { new Guid("a5b503eb-bead-453d-9752-c1adc186007f"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Drama" },
                    { new Guid("b331d8f2-2559-4a99-b430-0c6bd5feb2c8"), new Guid("e2e67ba5-7387-44ea-8957-a964f81f2138"), "" },
                    { new Guid("c4f78d20-1740-41af-98d1-9a914de517b5"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Romance" },
                    { new Guid("c5490393-73bb-4540-b8a9-e91ff9c8308d"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Musical" },
                    { new Guid("d3db1692-f62e-4d47-938c-ca213cbe87dc"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Slightly often" },
                    { new Guid("dd713fba-5803-4db4-8c99-c6a56701483b"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Not at all often" },
                    { new Guid("f55810c0-5b5e-4531-8b4e-03bc11136dab"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Comedy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeenMovies_MovieGUID",
                table: "SeenMovies",
                column: "MovieGUID");

            migrationBuilder.CreateIndex(
                name: "IX_SeenMovies_UserGUID",
                table: "SeenMovies",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeenMovies");

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("02ae396b-c39e-4039-88e1-0a5bf8220cf0"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("082286b0-8459-4775-93e9-5b78c28a8f80"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1242bcdd-639f-4a95-b637-52983404bbaf"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("199177f5-9fec-4466-bfea-4916e08e3020"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5dd625b2-5149-4188-8a07-808928fc228d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("79e99f78-ae0a-4330-97b0-3f25f327eb8d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("8e040ca0-51df-493a-b67d-a997edf559de"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("948f7a9d-aa95-4edf-8fce-b061af1d70f2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a1978dc5-bee9-4449-afe5-d26cbdb80c3e"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a5b503eb-bead-453d-9752-c1adc186007f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b331d8f2-2559-4a99-b430-0c6bd5feb2c8"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c4f78d20-1740-41af-98d1-9a914de517b5"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c5490393-73bb-4540-b8a9-e91ff9c8308d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d3db1692-f62e-4d47-938c-ca213cbe87dc"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("dd713fba-5803-4db4-8c99-c6a56701483b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("f55810c0-5b5e-4531-8b4e-03bc11136dab"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("72ca54af-43c1-481a-82ef-aef117f1c09b"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("c28c92ba-afa1-406c-b07e-f0611133187a"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("e2e67ba5-7387-44ea-8957-a964f81f2138"));

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("1252e712-6ecd-42a2-b59a-0d6951c9688e"), 2, "4.Who is your favourite director?" },
                    { new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("be4c17da-c102-43cd-83d6-73abf2a61ecb"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("d18549f2-e3ea-46cf-837a-1e93f2c914aa"), 1, "3.Who is your favourite actor?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("0e2c85eb-031a-4e0c-b9b5-56bfa1c3757b"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Very often" },
                    { new Guid("0fd432d1-8cea-4911-b9fa-84fe5064dee6"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Extremely often" },
                    { new Guid("144ff9bb-b1a3-4b94-bc85-7efeb8298159"), new Guid("d18549f2-e3ea-46cf-837a-1e93f2c914aa"), "" },
                    { new Guid("2a3254d0-0597-4edc-973c-9faccf83e3f4"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Comedy" },
                    { new Guid("30a998ca-b1cb-4546-830f-19b929be9a4b"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Not at all often" },
                    { new Guid("45a07eaf-0e86-444a-a0e0-e6536af21ad2"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Romance" },
                    { new Guid("4c40bb61-b50e-43ab-8a27-295fab186533"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Musical" },
                    { new Guid("7f3d8175-6a65-4341-8482-18b3809989ce"), new Guid("1252e712-6ecd-42a2-b59a-0d6951c9688e"), "" },
                    { new Guid("7f5c2559-17d3-483b-a4ac-7f8709bf0b7e"), new Guid("be4c17da-c102-43cd-83d6-73abf2a61ecb"), "" },
                    { new Guid("a37fbbcb-a83a-4280-8106-423c26ec5a73"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Action/Adventure" },
                    { new Guid("a62fce64-606d-4194-bdd0-b8435903e1a9"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Horror" },
                    { new Guid("ababf92c-37b5-4ec6-b091-e75dd12f5a08"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Drama" },
                    { new Guid("b13b5642-33a6-4fbe-93d2-1908cf941c7d"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Moderately often" },
                    { new Guid("c5adcf0f-5416-492a-be21-dd090baf15d7"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Slightly often" },
                    { new Guid("cdd05ed4-7a3a-4c1a-832d-a444e721c5fd"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Science-Fiction" },
                    { new Guid("de6fcaec-74f6-4103-bc60-e1c343a21f00"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Thriller" }
                });
        }
    }
}
